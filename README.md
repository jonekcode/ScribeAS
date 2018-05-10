
![](https://i.imgur.com/1iRhIRy.gif)

# ScribeBot

ScribeBot is a highly scriptable automation system.

With a little knowledge of Lua, you can automate mundane tasks, create macros or even create a bot.

<p align="center">
	<img src="https://i.imgur.com/GqcLPoj.png" />
</p>

### Join our discord server if you have questions/suggestions or a cool script to share: <a href=https://discord.gg/nXdGWnQ><img src="https://discordapp.com/assets/fc0b01fe10a0b8c602fb0106d8189d9b.png" width="100"></a>

## Important Notice
This program uses unmanaged code (see: [this](https://msdn.microsoft.com/en-us/library/ms973872.aspx#manunman_topic6) MSDN topic) and provides low-level functionality that if used improperly (intentionally or not) could affect system's security and reliability.
It's possible to write a malicious script - it's **highly advised** to open packages with package editor and read code before executing it, especially if it comes from untrusted sources.

## Program Features
- Lua interpreter plugged to numerous APIs and libraries - create robust systems without expert knowledge.
- Simple and easy interface - it's not beautiful, but it works.
- Packaging system - keep scripts and info about them bundled together.
- Workshop - find and download community-made scripts with just one click.
- Built-in package editor - edit packages without having to unzip them.
- Logging system - find out what broke when you were away.

## Libraries
|  Library  |                         Functionality (Short)                      | Third-party dependency |
| --------- | ------------------------------------------------------------------ | ---------------------- |
| audio     | Play sounds, get device current peak level                         |          NAudio        |
| core      | Manage windows, write to console, process console input            |            -           |
| database  | Read and save data to a local database                             |          SQLite        |
| input     | Emulate keyboard/mouse input                                       |            -           |
| interface | Create 'value input request' prompts                               |            -           |
| screen    | Recognize text, capture screen, read screen pixels, manage screens |        Tesseract       |
| webdriver | Create web automations                                             |         Selenium       |
| core      | Manage windows, write to console, process console input            |            -           |

## Known bugs and odd-behavior
- None

## Code Examples

Below you can find a simplistic stopwatch script.

It'll keep counting seconds that have passed since it's been started and it'll continue doing so until you set `count` to `false`.

`core.processConsoleInput()` is crucial here, otherwise sending `count = false` via console won't be executed.

```lua
count = true
i = 0

while(count) do
	i = i + 1

	print(i)

	wait(1000)

	core.processConsoleInput()
end
```

## Functions

Some functions that weren't listed below you can find [here](http://www.moonsharp.org/additions.html).

| Name | Function | Params | Returns |
| :--- | :--- | ---: | ---: |
| `audio.createDevice` | Create device for sound playing | - | AudioDevice device |
| `audio.getDeviceNames` | Get user-friendly device names | - | string[] names |
| `audio.getPeakValue` | Get peak value of a named device | string name | int peak |
| `audio.playNote` | Play note of a given frequency | (Enum)NoteFrequencies note | - |
| `core.close` | Close bot | - | - |
| `core.getFocusWindow` | Get title of currently focused window | - | string title |
| `core.setFocusWindow` | Set focus to a window of given title | string title | - |
| `core.getWindowPos` | Get position of a window | string title | Point pos |
| `core.setWindowPos` | Set position of a window | string title, number x, y | - |
| `core.getWindowSize` | Get size of a window | string title | Size size |
| `core.setWindowSize` | Set size of a window | string title, number w, h | - |
| `core.getWindowTitles` | Get titles of all windows | - | string[] titles |
| `core.isWindowVisible` | Get whether window is visible | title | bool isVisible |
| `core.processConsoleInput` | Process input entered into console | - | - |
| `core.write` | Write text to the console | string text | - |
| `core.writeLine` | Write colored (or not) text to the console | Color color, string Text ... | - |
| `core.version` | Get current bot version | - | string version |
| `database.query` | Execute a query on the local database | string query | - |
| `input.getCursorPos` | Get position of cursor | - | Point pos |
| `input.setCursorPos` | Set position of cursor | number x, y | - |
| `input.isKeyDown` | Get whether key is down | (Enum)VirtualKey key | bool isKeyDown |
| `input.isMouseDown` | Get whether mouse is down | number button | bool isMouseDown |
| `input.sendKeyDown` | Emulate key press | (Enum)VirtualKey key | - |
| `input.sendKeyUp` | Emulate key release | (Enum)VirtualKey key | - |
| `input.sendKeyPress` | Emulate key press and release | (Enum)VirtualKey key | - |
| `input.sendKeyPress` | Emulate key presses and releases | string sequence | - |
| `input.sendMouseDown` | Emulate mouse press | number button | - |
| `input.sendMouseUp` | Emulate mouse release | number button | - |
| `input.sendMousePress` | Emulate mouse press and release | number button | - |
| `interface.showPrompt` | Open window requesting value input | string message | string value |
| `screen.capture` | Capture and save screen and save to given path | string path | - |
| `screen.getPixels` | Get 2D array of all pixels in a given screen portion | number x, y, w, h | Color[][] colors |
| `screen.getSize` | Get total work-space (resolutions of all screens summed up) | - | Size size |
| `screen.recognize` | Try recognizing text on the screen | number x, y, w, h | string text |

<p align="center">
	<i>README last updated with upload of Release-0.65b</i>
</p>
