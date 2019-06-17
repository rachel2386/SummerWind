Thank you for purchasing my Tropical Forest Pack! I hope that you thoruoghly enjoy it and that it makes a great addition to your project.

The folder system is setup 

0)Demo folder has the three demos for Tropical Forest Pack including:

Forgotten Ravine DemoScene- The main demo scene featuring many effects and a fully developed terrain.

TFP- The original demo scene from Tropical Forest Pack that is a larger densly populated terrain. Do not recommend using a higher LOD bias in this scene as it is pretty dense.

TFP_Showcase- A simple scene showing the primary prefabs all together

1)Extra folder is filled with different things that are needed for the demo scenes. Includes Audio files, scripts, and shaders.
	
	The audio files are from Freesound.org. Edited by me in Audacity. All under the CC0 license //https://creativecommons.org/publicdomain/zero/1.0/
		
	Footstep_Sand: sand_step by pgi link- http://www.freesound.org/people/pgi/sounds/211457/
	jungle_ambience01: Tropical Birda by dubminister link- http://www.freesound.org/people/dubminister/sounds/214676/
	wind_in_trees: wind in trees from cover by strangy link- http://www.freesound.org/people/strangy/sounds/176253/

	Rest are different combinations of different audio files

	Many thanks to them for their amazing work.
	
	CTI Runtime Components for the LOD Tree and Billboard shaders, their needed wind script, and Deferred shaders. Many thanks to Lars for his work on the Custom Tree Importer and the amazing shaders. 

	ScenePrefabs includes additional prefabs setup for the two demo scenes.

	Scripts includes a few scripts made for the demo scenes.

	Shaders has some custom shader made in Shader Forge for things like water, rain, and mist particles in the demo scenes.

	Water is a collection of materials for the water and waterfalls for the demo scenes.

	There are also other small things for the demo scenes included in the Extra folder like 

		CTIDepth prefab that needs to be droped into any scene using Tropical Forest Pack prefabs in any Unity 5 version(depth normal input in Graphics Settins in Unity 2017, see at bottom)

		Directional light, FlyCamera prefab, Demo Scene terrain data and the windzone prefab.

2)Prefabs folder. This is setup so you have your already setup prefabs for quick use. You have the GroundCover, Particles, Props, Rocks, Trees, & VS. 

	The GroundCover and Trees folder each have a Billboards folder and this is just to store the Billboards asset for each prefab that uses a billboard.

	In the Trees folder you have all the trees you can input right in the terrain system and an LODs folder. Each tree has an enabled capsule collider for collision 
	on the terrain. Most of the trees also have a disabled Mesh Collider that is setup with the imported collider mesh. So if you are placing them 
	manually and not on the terrain you can disable the capsule collider and enable the mesh collider. The KapokTree01 has its capsul collider disabled by default as it is 
	not a good collision meathod for this particular tree. If you want to use it as a terrain object than just disable the Mesh Collider and enable the Capsule Collider in the prefab under the LOD Group Component.

	The VS folder includes all the assets optimized for use with Vegetation Studio. It also includes the configured profiles and biomes for use with Vegetation Studio. 

3)Imports folder contains the different meshes. The Colliders, GroundCover, Particle, Props, Rocks, and Tree imports.

4)Materials folder contains the materials for the main assets. Ground, GroundCover, Particle, Props, Rocks, and Trees.

5)Textures folder. Contains all the textures for the pack.
	
	Some of the textures in this pack are from textures.com(formerly CGTextures)link- http://www.textures.com/
	Edited and made seamless. Also made maps for them.
	The rest were made by me by either photography, photogrammetry, or modeled and rendered.

Important -- The shaders for Tropical Forest Pack support Fully Deferred Rendering and require the Deferred shaders inputed into Edit-Project Settings-Graphics. Towards the bottom under  
Built-in shader settings find the Deferred and Deferred Reflections tabs. Click the tab and select Custom Shader in the dropdown for both. Input CTI/Internal-DeferredShading for Deferred and 
CTI/Internal-DeferredReflections for Deferred Reflections. Now the trees should shade correctly in Deferred Rendering. 

Also in Unity 2017.1 and up input the Hidden/Camera-DepthNormalTexture shader into the Depth Normals slot. 

Video tutorials for both these processes is linked on the thread and Asset Store page.

Thank you again for purchasing the Tropical Forest Pack! For any issues please contact me on the thread that is linked in the Asset Store page or email me at baldinoboy@gmail.com