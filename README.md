# Puzzle-Project
 
Building System Requirements

A computer with the following specifications:
*From https://docs.unity3d.com/Manual/system-requirements.html#limitations

Minimum requirements	

Windows		<br>
Operating system version:	Windows 7 (SP1+), Windows 10 and Windows 11, 64-bit versions only.		<br>
CPU:	X64 architecture with SSE2 instruction set support		<br>
Graphics API:	DX10, DX11, and DX12-capable GPUs		<br>
Additional requirements:	Hardware vendor officially supported drivers		<br>

macOS<br>
Operating system version: High Sierra 10.13+ (Intel editor), Big Sur 11.0 (Apple silicon Editor)<br>
CPU: X64 architecture with SSE2 instruction set support (Intel processors)<br>
     Apple M1 or above (Apple silicon-based processors)<br>
Graphics API: Metal-capable Intel and AMD GPUs<br>
Additional requirements: Apple officially supported drivers (Intel processor)<br>
                         Rosetta 2 is required for Apple silicon devices running on either Apple <br>
                         silicon or Intel versions of the Unity Editor.<br>

Linux<br>
Operating system version: Ubuntu 20.04, Ubuntu 18.04, and CentOS 7<br>
CPU: X64 architecture with SSE2 instruction set support<br>
Graphics API: OpenGL 3.2+ or Vulkan-capable, Nvidia and AMD GPUs.<br>
Additional requirements: Gnome desktop environment running on top of X11 windowing system, Nvidia official proprietary<br> 
    graphics driver or AMD Mesa graphics driver.<br>
    Other configuration and user environment as provided stock with the supported distribution (Kernel, Compositor, etc.)<br>

Running System Requirements

Operating system	Android
Version	8.1 or later
CPU	ARMv7 with Neon Support (32-bit) or ARM64
Graphics API	OpenGL ES 3.0+, Vulkan
Required Space	300 MB (For install file)
               55 MB (For installed app) Internal or External memory


Source Code

All of the files and folders in this repository: 
  

Build Instructions

1)	Download and install the Unity Hub available here for the appropriate operating system:

      https://unity.com/download 
 	

2)	From the Unity Hub, Install Unity Editor version 2020.3.33f1 LTS. When given the list of installable features, choose to install all Android Development options.
 
3)	Clone the GitHub repository into the directory that you intend to build into using either the command line, GitHub Desktop, or the ZIP download. 
	 
4)	In the Unity Hub, click Open.

5)	Browse to the directory downloaded in Step 3. Click Open

6)	In the File menu, go to Build Settings, and change the environment to Android. (This may require an additional download)
 
7)	Press Build and save the apk file to another directory. 

8)	In your file explorer, find the apk you saved and move it onto your Android mobile device by any available means.
 
9)	Install the app on your device using the Package Installer.
 
10)	Open the app and play!

