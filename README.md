# Teamsjoiner
A bot to join teams meetings when you're away, so you can be anywhere you like!

## IMPORTANT
This ONLY works with the teams app on pc, please download the desktop teams app and use it with that :)

The application will stop responding when its waiting, this is not an issue and it works that way, untill i find a better way it will stay like this.

Please also note that the application will come up as an unrecognised app, i kindly ask you to press more info-run anyway when it pops up, thanks in advance!

## How to use
here's how to use it. Again, it is supposed to be straightforward. make sure the chat is open where the meeting will be posted as this bot uses the colour of the "join" button to click it!

![](images/howitworks.png)

## The UI
The UI is designed to be user friendly too, as a creator with no knowledge of UI design at all, i'm proud. Heres a quick look:

![](images/blackui.png)

## Useful Links
Here you can find a few links to google forms i have set up and a link to my github page, needs some work but will be updated as soon as possible!

![](images/usefullinks.png)

## How it works
First, you input the time from now till the lesson starts. The program converts this, and the other number you put in into milliseconds, then it uses the 'new System.Threading.ManualResetEvent(false).WaitOne();' function to wait the time you have stated, plus an extra 15 seconds incase the meeting is late. 

Then on the teams desktop app, the 'join' button to join a meeting has a certain few pixels with a unique colour on it (i found this with instant eyedropper), from there it clicks on the specified pixel. on the second screen, the 'join now' option also has unique colour pixels, so it made it easy. 

After the lesson starts, the same method as used in the first part waits the desired time until the lesson is over, then it searches for the red pixels in the 'leave' button. If its there, it clicks it. 

-- i am currently working on a feature where it retries after 1 minute everytime till the process ends or the button is found --


