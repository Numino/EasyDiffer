An interface to quickly compare files. Built in C# with Photino and Blazor and using MudBlazor components.
The diff itself is just a monaco instance but had to use HttpListener to host the content to get around browser restrictions (web workers) with standard Photino.Blazor.
Also an example for Mac cocoa interop for extending the menu bar that lets CMD + C and CMD + V work
