# Family List
This is the project that was built in class and has added the SQLite storage of the family members.  It has also been modified to use the following approach to get around limitations with the Portabl Class Library.

## `Environment.GetFolderPath()` and Portable Class Libraries
It turns out that one cannot use the `Environment.GetFolderPath()` method within Portable Class Library projects.  When I built the app in class I created the project as a .NET Standard project, not a Portable Class Library project.  I was able to do this because I updated Visual Studio for Mac to the latest, which required updating MacOS to the latest version and updating XCode.

Currently the Mac virtual machines that students have access to are not configured this way and projects that are created on non-updated Mac Virtual Machines will create Portable Class Library projects and thus have an issue with using Environment.GetFolderPath().

# Solution #1 - Update a bunch of stuff (and redo)
The above issue can be resolved by updating a bunch of stuff.  You may be able to do the following:
- Update MacOS to the latest
- Update XCode to the latest
    - After updating XCode to the latest, you will have to actually open XCode itself which will prompt to install necessary components.  Do that.
- Update Visual Studio for Mac to the latest

After updating all the above (which will take some time), it will not magically fix your existing code as the C# solution is already using a Portable Class Library.  To use .NET Standard library (which will allow you to use `Environment.GetFolder()`) you would have to create a new solution and re-implement the entire App.

This approach may not be ideal as it would require one to redo everything for the app, but it should work.

# Solution #2 - Use `Xamarin.Forms.DependencyService`

So the problem is that Portable Class Libraries cannot reference `Environment.GetFolderPath()`, so how can we get around this?  Well, neither the App.iOS nor the App.Android projects are Portable Class Libraries and can use Environment.GetFolderPath() within these projects.  So we can implement code in these projects and use them by the Portable Class Library project indirectly.

## Step 1 - Define an interface
In the App (Portable Class Library) project create an interface.  Let's call it `IDbPathProvider`.  By convention, interface names are prefixed with a capital __I__.  An interface is similar to a class as it defines a datatype (just like a class does), but __only__ defines its public API and not its actual implementation.  It can be thought of as a contract stating that any class that implements the interface, must define what it stated in the interface definition.  Here's the `IDbPathProvider` interface definition:

```C#
    public interface IDbPathProvider
    {
        string GetDbPath();
    }
```

All the above is stating is that there must be a method with the namd `GetDbPath` that takes zero parameters and returns a string.

## Step 2 - Implementation of Interface (for Android)

In the App.Android project, create a new class which implements the `IDbPathProvider` interface defined above.  Do so by adding a new class to the App.Android project and lets call it `DbPathProviderForAndroid`.  To signify the class is implementing the `IDbPathProvider` interface we specify the `IDbPathProvider` interface after a colon.  We can then implement the class (including the interface definition) as below:

```C#
    public class DbPathProviderForAndroid : IDbPathProvider
    {
        public string GetDbPath()
        {
            string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            string dbFileName = "myFamilyAndroid.db3";

            string dbFullPath = System.IO.Path.Combine(directoryPath, dbFileName);

            return dbFullPath;
        }
    }
```

As one can see, this class is providing the implementation of the interface which simply specifies the file path to the database file we wish to use.  Since this class is implemented in the App.Android project (which is not a Portable Class Library) we are able to use the `Environment.GetFolderPath()` method to get the proper location.

## Step 3 - Implementation of Interface (for iOS)

In the App.iOS project, create another new class which implements the `IDbPathProvider` interface.  Do so by adding a new class to the App.iOS project and call it `DbPathProviderForIOS`.  Simliar to the implementation for Android, we signify the class is implementing the `IDbPathProvider` interface like before.  We can then implement the class (including the interface definition) as below:

```C#
    public class DbPathProviderForIOS : IDbPathProvider
    {
        public string GetDbPath()
        {
            string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            string dbFileName = "myFamilyIOS.db3";

            string dbFullPath = System.IO.Path.Combine(directoryPath, dbFileName);

            return dbFullPath;
        }
    }
```

Again, this is just utilizing the `Environment.GetFolderPath()` method much like the Android implementation is doing.

Also note the file names differ between the two implementations.  This is not a requirement, but just demonstrating how we may wish to use a different file name (or even location) if desired.

## Step 4 - Wiring everything up using `Xamarin.Forms.DependencyService`

The `IDbPathProvider` interface is defined in the App Portable Class Library, however the implementations are defined in the App.Android and App.iOS projects.  We must somehow configure the app to give to us the correct implementation (either `DbPathProviderForAndroid` or `DbPathProviderForIOS`) at runtime.  As far as the App is concerned, it does not care which implementation of the `IDbPathProvider` is used, so long as it gets some sort of implementation, it is happy.

### For Android
In the App.Android project, open the MainActivity.cs file.  This code is executed when the Android app is first launched.  This is what tells Android to create an instance of our Xamarin.Forms App and start it.  However before we can instantiate our App class, we must first register with `Xamarin.Forms.DependencyService` our Android-specific implementation of the `IDbPathProvider` interface.

```C#
    protected override void OnCreate(Bundle savedInstanceState)
    {
        TabLayoutResource = Resource.Layout.Tabbar;
        ToolbarResource = Resource.Layout.Toolbar;

        Xamarin.Forms.DependencyService.Register<DbPathProviderForAndroid>();

        base.OnCreate(savedInstanceState);
        global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
        LoadApplication(new App());
    }
```

Notice the `Xamarin.Forms.DependencyService.Register<DbPathProviderForAndroid>();` line of code.  This is where the code is registering with Xamarin.Forms' `DependencyService` class.  Since our `DbPathProviderForAndroid` implements the `IDbPathProvider` interface, this instructs that if we ask the `DependencyService` for an implementation of the `IDBPathProvider` interface it will create an instance of the `DbPathProviderForAndroid` class.

### For iOS
In the App.iOS project, open the AppDelegate.cs file.  Similar to how an Android app first launches it first executes the code in the MainActivity.cs file, in iOS when an iOS app first launches, it executes the code in the AppDelegate.cs file.

In the AppDelegate.cs file, we must register with `Xamarin.Forms.DependencyService` the iOS-specific implementation fo teh `IDbPathProvider` interface.

    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
        global::Xamarin.Forms.Forms.Init();

        Xamarin.Forms.DependencyService.Register<DbPathProviderForIOS>();

        LoadApplication(new App());

        return base.FinishedLaunching(app, options);
    }

Again, notice the `Xamarin.Forms.DependencyService.Register<DbPathProviderForIOS>();` line of code.  This is what instructs the `DependencyService` to create an instance of `DbPathProviderForIOS` when code requests an instance of an `IDbPathProvider`.  Since the `DbPathProviderForIOS` implements the `IDbPathProvider` interface the `DependencyService` class is able to figure this out when necessary.

### Bringing it all together.
In the FamilyMemberDatabase.cs file we can get a reference to an implementation of the IDbPathProvider interface by using the `Xamarin.Forms.DependencyService` class.


```C#
    public class FamilyMemberDatabase
    {

        SQLite.SQLiteConnection dbConnection;

        public FamilyMemberDatabase()
        {
            IDbPathProvider pathProvider = Xamarin.Forms.DependencyService.Get<IDbPathProvider>();

            string dbFullPath = pathProvider.GetDbPath();

            dbConnection = new SQLite.SQLiteConnection(dbFullPath);

            dbConnection.CreateTable<FamilyMember>();
        }
    
    ...
    }

```

Notice how in the constructor we are getting a reference to an implementation of the `IDbPathProvider` interface by calling `Xamarin.Forms.DependencyService.Get<IDbPathProvider>()`.  

 - For Android
    - When the app first launches it calls `Xamarin.Forms.DependencyService.Register<DbPathProviderForAndroid>();` (see MainActivity.cs)
    - Therefore when code later calls `Xamarin.Forms.DependencyService.Get<IDbPathProvider>()` it will return an instance of the DbPathProviderForAndroid.

 - For iOS
    - When the app first launches it calls `Xamarin.Forms.DependencyService.Register<DbPathProviderForIOS>();` ( see AppDelegate.cs)
    - Therefore when code later calls `Xamarin.Forms.DependencyService.Get<IDbPathProvider>()` it will return an instance of the DbPathProviderForIOS.


Since our code in the App project (which is a Portable Class Library) is happy as long as gets an implementation of the `IDbPathProvider` interface, it does not know (or even care) which implementation it gets.  The code just knows that it is some implementation of the interface and thus `GetDbPath()` can be called and provide us the correct path to the SQLite database file we wish to use.