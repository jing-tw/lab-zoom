# Modified Zoom Client Example
Add automatic generate JSON Web Token for App Token by giving SDK key and SDK secret. Never hardcode your SDK Key or Secret in your application or anywhere that is publicly accessible.

#  Build & Run & Test
## Setup SDK key and SDK secret
1. Edit 
```bash
File: MainWindow.xaml.cs
string apiKey = "YOUR_SDK_KEY";         // get it from Zoom marketplace. https://marketplace.zoom.us/
string apiSecret = "YOUR_SDK_SECRET";   // get it from Zoom marketplace. https://marketplace.zoom.us/
```

## Build & Run
1. Open the solution
```bash
File: zoom_sdk_c_sharp_wrap\zoom_sdk_c_sharp_wrap.sln
```
2. Build
3. Click Auth button (Don't care the input field) 
