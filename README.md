## War Thunder Applet
Small War Thunder Applet for the G19 / G15 (possibly) Keyboard using C#. Used to display possibly smaller radar map and other information.

Credit goes to [Dan Minut](http://www.mangareader.com/dmclglcd.html) for providing a great example and starting point. Using the provided DMcLgLCD.dll provided by Dan Minut. You will need to download the dll from his site.
 
## Current Status
###Note
I requested some information from Gaijin about the live map (browser). I was promptly denied any information as it is consider confidential. I was looking at some guidance of the endpoints might return (json). This will result in slower progress.
###Features
1. Speed 
2. Altitude
3. Throttle
4. Aircraft Name (if available)
5. Flaps %
6. Water Temp 1 
7. Water Temp 2
8. Oil Temp 1
9. Oil Temp 2
10. Live Map (in progress not complete)
11. 
![Current ScreenShot Status](https://raw.githubusercontent.com/nrobison/WarThunderApplet/develop/Screenshots/Screenshot_1.JPG)
### Known Issues
1. Altitude will not display on some aircraft (indicators not returning from War Thunder)
2. Aircraft Name as well not returning on Bombers (see above)
3. json return from War Thunder not completely consistent
4. Have not add all map objects (fighters, ground units etc)
5. Have not explored Tanks yet

### To Do
1. Finish adding all objects to mini map
2. Add customization to layout (change properties)
3. Provide stable package for installing to G19
4. Provide G15 (monochrome) output (Maybe, can't test will need a user with g15)
5. Add Tank support

##Logitech C# Wrappers are lacking see above link and Info
~~For the needed  C++ dll files see [Logitech G Developers Lab](http://gaming.logitech.com/en-us/developers) and download Game Panel SDK.
Decent documentation is available in PDF format from Logtiech in the download. See above for a better example if you want to get started on your own.~~

