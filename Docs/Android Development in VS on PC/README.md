# Working in Windows
How to get a working Android emulator working with Visual Studio.

## On your Mac Virtual Machine

### Install Git
Go to https://git-scm.com/downloads and download the latest.  Install it once downloaded.

### Create new App in Visual Studio for Mac
Make sure to select add Git Repository.

![Screenshot](VSMacCreateProjectWithGit.PNG)

Once done, make sure to commit all changes to your local Git repository.

![Screenshot 2](VSMacCommitChangesToGit.PNG)

![Screenshot 3](VSMacCommitChangesToGitDialog.PNG)
After committing the changes, a "snapshot" will be created saving the current state of all tracked files to the local Git repository.



### Create GitHub Repository

![Screenshot 4](GitHubNewRepoDropdown.png)

![Screenshot 5](GitHubNewRepoComplete.PNG)

![Screenshot 6](GitHubNewRepoPage.PNG)
Note the HTTPS URL for your Git Repository

Add your GitHub repository as a remote for your local Git repository.
![Screenshot 7](VSMacManageBranchesRemotes.PNG)

![Screenshot 8](VSMacAddRemoteOrigin.PNG)

Push your commits from your local Git repository to your GitHub repository.

![Screenshot 9](VSMacGitPushChanges.PNG)

![Screenshot 10](VSMacGitPushChangesDialog.PNG)

Enter your GitHUb credentials
![Screnshot 11](VSMacGitPushChangesCredentials.PNG)

View all files on GitHub in browser.
![Screenshot 12](GitHubViewRepoWithPushedChanges.PNG)

## On Windows PC

### Install Git
Go to https://git-scm.com/downloads and download the latest.  Install it once downloaded.

### Install Android Studio
Once installed, open Android Studio.

This will download the Android SDK and most other required software.

Create a new project in Android Studio.  This actual project will not be needed, just click through the prompts to get to Android Studio.

Android Studio may display errors in the bottom that you may be missing necessary components.  Click the links it suggests to resolve any issues.

Open the Android SDK Manager

![](AS-OpenSDKManager.png)

Make sure to have Android SDK Tools version 26 installed.

![](AS-SDKManager-SDKTools.png)

Create desired emulator by opening the Android AVD Manager

![](AS-AVDManager-Menu.png)

Click the Create Virtual Device button.

![](AS-AVDManager.png)

Choose your desired device definition.

![](AS-AVDManager-DeviceDefinition.png)

Select the desired version of Android to be used.

![](AS-AVDManager-SelectSystemImage.png)

(download if necessary)
![](AS-AVDManager-DownloadingSystemImage.png)

Give your emulator a name
![](AS-AVDManager-NameYourEmulator.png)

Start your emulator
![](AS-AVDManager-StartEmulator.png)

![](AS-EmulatorStarting.png)

### Install Visual Studio

Make sure to select Mobile App Development feature set during installation.
![Screenshot 13](VSInstallerWorkloadsMobileAppDevelopment.png)

If this is not selected, you may modify your installation of Visual Studio by opening the Visual Studio 2017 Installer app.

### Open Visual Studio

Open Viual Studio
![Screenshot 14](VSOpened.png)

Go to the Team Explorer tab
![SCreenshot 15](VSTeamExplorerTab.png)

Clone the GitHub Git repository
![Screenshot 16](VSTeamExplorerTabCloneRepo.png)

Once the clone operation completes, Visual Studio will open the cloned repository in the Solution Explorer tab.
![Screenshot](VSSolutionExplorerTab-Files.png)

Double click the solution file to open the solution (originally created by Visual Studio for Mac)

![](VSSolutionOpened.png)

Choose the Android project as the Startup Project 

![](VSChooseDroidStartupProject.png)

Choose the Emulator created by the AVD Manager

![](VSChooseAndroidEmulator.png)

Start debugging.

![](VSAndroidEmulatorRunningApp.png)

Presto!

# Bonus

## View the iOS Simulator from Visual Studio (for Windows)

```
This process will only work while you are on campus at FVTC 
as the Mac Virtual Machines are not accessible via the internet.

If you have your own Mac on your home network, however, the same
process may be done at home.
```


### Enable SSH Connections to your Mac Virtual Machine
Open System Preferences for your Mac Virtual Machine

![](Mac-ApplicationsSystemPreferences.png)

![](Mac-SystemSettings.png)

Select the Sharing icon
![](Mac-SystemSettings-Sharing.png)

Enable the Remote Login service and allow the desired users.
![](Mac-SystemSettings-Sharing-RemoteLogin.png)

You will need to know the Mac's IP address in order to connect to it.

In System Preferences

![](Mac-SystemSettings.png)

 click the Network icon.

 ![](Mac-SystemSettings-Network.png)

 Note your Mac Virtual Machine's IP address (10.4.XXX.XXX)


### Connect to your Mac Virtual Machine from Visual Studio on PC

Open your project in Visual Studio (on PC).

Select the iOS project as your startup project.

![](VSChooseiOSStartupProject.png)

Click the Simulator button to begin debugging.

![](VSClickSimulatorButton.png)

Since you have not connected to your Mac Virtual Machine yet, Visual Studio will prompt you to enter your server information.

![](VSChooseMacBuildServer.png)

Click the `Add Server...` button and enter the IP address of your Mac Virtual Machine.

![](VSAddMacBuildServer.png)

Enter your username and password to connect to the Mac Virtual Machine with

![](VSMacServerCredentials.png)

After Visual Studio connects to your Mac Virtual Machine you will see this.

![](VSMacBuildServerConnected.PNG)

You can now close this window.

Now in the debug toolbar, you will be able to choose any of the iOS Simulator hardware profiles your Mac Virtual Machine has installed.

![](VSSelectIOSSimulatorHardware.png)

After selecting your desired hardware/iOS version, you can click to start debugging.

If you watch your Mac Virtual Machine during this process, you will notice the iOS Simulator start and display your App.

Screenshot from Mac:

![](Mac-SimulatorRunningApp.png)

On the Windows PC, a screen displaying the iOS Simulator will also run.

![](VSiOSSimulatorRunningApp.png)

Hooray!

It is important to realize that the actual app is running on the iOS Simulator on the Mac Virtual Machine, only the display is shown remotely on the Simulator running on the PC.

You may interact with the iOS Simulator on the PC.  Doing so will send any interactions to the Simulator running on the Mac and display the results.

## Making changes to app in Visual Studio (on PC) and using Git

You may make changes to the app in Visual Studio (on PC) and commit any changes to the Git repository on your PC.

![](VSChangeToXamlFile.png)

Any additional changes may also be done as well.

Go to the Team Explorer tab in Visual Studio.
![](VSTeamExplorerTabWithOpenSolution.png)

Click the `Changes` button

Visual Studio will show all changes* made to any file in the Git repository.
![](VSTeamExplorerChanges.png)

```
Changes to files can be ignored automatically 
by editing the .gitignore file.  Therefore not every file
containing modifications may be listed.

(more on this later)
```

Right click on any files/folders you wish to commit to the Git repository and select `Stage`.

(Only *Staged* changes will be committed.  You must manually add the files you wish to commit by selecting them to be staged)

Enter a comment describing *why* changes were made (not *what* changes were made, that can be seen quite simply by viewing the file.)

![](VSTeamExplorerStagedChanges.png)

Click `Commit Staged`

![](VSTeamExplorerChangesCommitted.png)

Note that the changes were only committed to your local Git repository.  Nothing has been shared to any other repository (eg: GitHub) yet.

To `push` your local commits to a remote repository, click Sync from the Team Explorer tab.
![](VSTeamExplorerTabSyncButton.png)

From here you can `pull` changes from the remote repository or `push` your local commits to the remote repository.

- A `pull` will retrieve any commits from the remote repository and merge them into your local repository.  Often times this will create an additional `merge-commit` automatically.  However sometimes you may have to manually merge the changes into your local repository if there are conflicting changes.

- A `push` will attempt to submit your local commits to the remote repository.  This may fail if the remote repository has additional commits that you have not merged into your local repository yet.

Push your changes to the remote repository.

![](VSTeamExplorerPush.png)

You may be prompted to enter your GitHub credentials:

![](VSTeamExplorerPushGithubCredentials.png)

When completed you will see a message telling you so.

### Now lets retrieve the changes from the Mac Virtual Machine

The Mac's local Git repository does not yet contain the changes that were made in the PC environment.  To retrieve those changes first open the Solution in Visual Studio for Mac (if not opened already).

Select Version Control --> Update Solution

![](VSMacVersionControlUpdateSolution.png)

*WARNING!!!* This process will do a Git `stash` operation without notice.  

A `stash` operation will wipe out any un-staged changes you may have made.  This is the exact gotcha that caused me to lose all changes made for a demo app for Week 6.  Live and learn.

Make sure to have any changes you wish to preserve at least staged prior to doing this operation from Visual Studio for Mac.

Alternatively, you can perform the Git `pull` operation manually from the terminal

```
# Change directory to the directory containing my Git repository
cd Projects/DemoGitApp/

# Tell Git to pull all changes from the remote repository
git pull
```

![](MacGitPull.png)

Doing a manual Git `pull` does not cause an automatic (and unprompted) Git `stash` operation.

Now if we open any files we modified, committed, and pushed from Visual Studio (on PC), we shall see them in Visual Studio for Mac as well.

![](VSMacShowModifiedXamlFile.png)

And we can start the iOS simulator demonstrating the changes.

![](VSMacSimulatorRunningWIthChanges.png)

Voila!

Now we can work in either Mac or PC and share code back and forth with a well known and industry-standard source control process.
