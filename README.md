# Clouds Awakening Trouble: Rickety Risks and Magic Tricks

A collaborative project with fellow Centre for Digital Media Cohort C14 Members: Jeanette (UX/UI Designer), Maple (Project Manger), Andre (2D/3D Artist), Alessandra(UX/UI Designer), and myself Irene (Programmer). 

A mobile 2D game with stacking and balancing mechanics. As per the challenge design, it also incoporates a proof of concept reward/buff system. Aside from implementing iterative game design development, it makes usage of ScriptableDataObjects for scalable code. 


# Instructions to Download these Draft Unity Apps onto your phones:

I'm looking into making this download process smoother but i'm not going to focus on that until i really need to publish this. 

1) download the zip file and unzip it into a folder on your DESKTOP  folder. this is important.

2) This step is going to be a little tricky.

Open Finder > Applications > Utilities > Terminal. If you're not used to a terminal, this is going to feel weird. This is to give your computer permission to 
use these files for the app. 

Type in the following. 

cd Desktop [press enter]

chmod -R +x < unzipped folder name > [press enter]

It should look like the following

![Terminal Permissions](https://i.imgur.com/0ayXE2L.png)


3) Install XCode, if it's not on your computer, go to the apple app store and search "Xcode". First result. Hammer with a blueprint icon. 
4) Open Xcode. On the top bar select xcode > Preferences > Accounts 

![XCODE Toolbar](https://i.imgur.com/QzQzjyK.png)

5) Add your Apple ID account by pressing the plus sign as shown. Fill in details.
![APPLE ID LOGIN](https://i.imgur.com/NSZGfol.png)

6) Now go to finder. Open the zip file that you've downloaded. Open that folder. Double click on "Unity-iPhone.xcodeproj". It will probably have a 
big red error show up. That's expected. It's a bunch of security measures to make sure they can track down people if they create virus apps. 

Click on this triangle caution icon. 

![XCODE WARNING BUTTON](https://i.imgur.com/bynw0FK.png) 

7) You'll see on your left there's a screen that says "General, Signing & Capabilities, Resource Tags etc..."
Click on "signing & capabilities" and you'll see the below.

![XCODE SIGNING PERMISSIONS](https://i.imgur.com/xAmItcy.png)
From the drop down select your apple id (personal team). .... Ignore my pseudonym. 

8) Plug in your iphone with a USB Cord. 
It should look like this:
![XCODE](https://i.imgur.com/DwMZuVW.png)
Press the play button. Wait for it to finish loading
9) Enter your mac password when the mac asks and then you'll see the app appear on your phone. 

10) On your phone go to Settings > General > Device Management > Apple Development > Trust "Apple Development ... etc"









