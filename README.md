Gameboy Effect
======

This is an example Unity3D project that pixelates the output and quantizes to four colors, to look like a Game Boy game.

Unity3D Pro has Image Effects, which makes this easy to do. For Unity3D free however, it's doable but *very* inefficient.

It works by grabbing the framebuffer using [ReadPixels](http://docs.unity3d.com/ScriptReference/Texture2D.ReadPixels.html), drawing a screen filling quad using [straight GL](http://docs.unity3d.com/ScriptReference/GL.html) and postprocessing using a shader.

In my machine (which is pretty powerful) this scene is already down to around 180fps with vsync turned off. The scene itself does basically nothing, without this post-processing it's in the thousands. It's pretty inefficient, but that's what you get by not using render to texture.

I don't know if there are any other ways to make it faster, because it seems that the bottleneck is the ReadPixels. Buy Unity Pro if you want something more efficient :) 

Feel free to use this however you want for any kind of project, no need to attribute or ask permission.

Usage
======

In order to use this in your project, you just need PixelatedEffect.cs and pixel.shader. Attach the PixelatedEffect script to the camera, and link the Shader to it. You might also want to remove the OnGUI button.

If you choose a factor of 4x to upscale, and you want a game resolution of e.g. 160x144 (Game Boy), you need to set the Unity resolution to 4 times that value, so 640x576.