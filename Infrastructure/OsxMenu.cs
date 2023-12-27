using System;
using System.Runtime.InteropServices;

namespace JsonDiffer.Infrastructure;

public static class OsxMenu
{
    private static IntPtr nsString = objc_getClass("NSString");
    private static IntPtr nsMenu = objc_getClass("NSMenu");
    private static IntPtr nsMenuItem = objc_getClass("NSMenuItem");

    public static void CreateEditMenu()
    {
        var editMenu = objc_msgSend(objc_msgSend(nsMenu, sel_registerName("alloc")), sel_registerName("init"));
        AddMenuItem(editMenu, "Cut", "cut:", "x");
        AddMenuItem(editMenu, "Copy", "copy:", "c");
        AddMenuItem(editMenu, "Paste", "paste:", "v");

        var editMenuItem = objc_msgSend(objc_msgSend(nsMenuItem, sel_registerName("alloc")), sel_registerName("init"));
        objc_msgSend(editMenuItem, sel_registerName("setSubmenu:"), editMenu);
        objc_msgSend(editMenuItem, sel_registerName("setTitle:"), NSStringFrom("Edit"));

        var mainMenu = objc_msgSend(objc_msgSend(objc_getClass("NSApplication"), sel_registerName("sharedApplication")), sel_registerName("mainMenu"));
        objc_msgSend(mainMenu, sel_registerName("addItem:"), editMenuItem);
    }

    private static void AddMenuItem(IntPtr menu, string title, string action, string keyEquivalent)
    {
        var menuItem = objc_msgSend(objc_msgSend(nsMenuItem, sel_registerName("alloc")), sel_registerName("init"));
        var titleString = NSStringFrom(title);
        var actionSelector = sel_registerName(action);
        var keyEquivalentString = NSStringFrom(keyEquivalent);

        objc_msgSend(menuItem, sel_registerName("setTitle:"), titleString);
        objc_msgSend(menuItem, sel_registerName("setAction:"), actionSelector);
        objc_msgSend(menuItem, sel_registerName("setKeyEquivalent:"), keyEquivalentString);
        objc_msgSend(menu, sel_registerName("addItem:"), menuItem);
    }

    private static IntPtr NSStringFrom(string str)
    {
        return objc_msgSend(objc_msgSend(nsString, sel_registerName("alloc")), sel_registerName("initWithUTF8String:"), str);
    }

    [DllImport("/System/Library/Frameworks/AppKit.framework/AppKit")]
    private static extern IntPtr objc_getClass(string className);

    [DllImport("/System/Library/Frameworks/AppKit.framework/AppKit")]
    private static extern IntPtr objc_msgSend(IntPtr receiver, IntPtr selector);

    [DllImport("/System/Library/Frameworks/AppKit.framework/AppKit")]
    private static extern IntPtr objc_msgSend(IntPtr receiver, IntPtr selector, string arg1);

    [DllImport("/System/Library/Frameworks/AppKit.framework/AppKit")]
    private static extern IntPtr objc_msgSend(IntPtr receiver, IntPtr selector, IntPtr arg1);

    [DllImport("/System/Library/Frameworks/AppKit.framework/AppKit")]
    private static extern IntPtr sel_registerName(string selectorName);
}