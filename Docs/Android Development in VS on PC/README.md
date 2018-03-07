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



Presto!

# Bonus

## View the iOS Simulator from Visual Studio (for Windows)
