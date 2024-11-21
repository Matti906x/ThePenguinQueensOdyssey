using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWindowSize : MonoBehaviour
{
    void Start()
    {
        int renderWidth = 1920;  // Internal rendering resolution width
        int renderHeight = 1080; // Internal rendering resolution height
        int windowWidth = 1024;  // The actual window width on screen
        int windowHeight = 576;  // The actual window height on screen
        bool isFullScreen = false;

        // Set the rendering resolution
        Screen.SetResolution(renderWidth, renderHeight, isFullScreen);

        // Adjust the window size (for Windows platform)
        AdjustWindowSize(windowWidth, windowHeight);
    }

    void AdjustWindowSize(int width, int height)
    {
        // For Windows only - Adjust the window size independent of the rendering resolution
        #if UNITY_STANDALONE_WIN
        System.IntPtr hWnd = GetActiveWindow();
        RECT rect = new RECT();
        GetWindowRect(hWnd, ref rect);

        // Adjust the window size while keeping the original position
        MoveWindow(hWnd, rect.left, rect.top, width, height, true);
        #endif
    }

    // Windows API functions
    #if UNITY_STANDALONE_WIN
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern System.IntPtr GetActiveWindow();

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern bool GetWindowRect(System.IntPtr hWnd, ref RECT lpRect);

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern bool MoveWindow(System.IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

    private struct RECT
    {
        public int left, top, right, bottom;
    }
    #endif
}
