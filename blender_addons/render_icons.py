# For use in icon_geom.blend, https://wiki.blender.org/wiki/Source/Interface/Icons 
# Downloaded from https://svn.blender.org/svnroot/bf-blender/trunk/lib/resources/
import bpy

# Render settings
render_directory = 'D:/Projects/C#/BlenderStreamDeckIntegration/images/sculpt/'
bpy.context.scene.render.resolution_x = 144 # Size per Elgato's style guide. https://developer.elgato.com/documentation/stream-deck/sdk/style-guide/#sizes
bpy.context.scene.render.resolution_y = 144
bpy.context.scene.render.film_transparent = True 

# Setup objects
camera = bpy.context.scene.camera
objects = bpy.data.collections['Sculpt Mode'].objects # This includes child objects in the collection...
objects = [obj for obj in objects if not obj.parent] # ...so only get the root objects.

# Render object after object.
for obj in objects:
    # Slicing is unintuitive. It's the indices the elements to include are between, not the indices of the elements themselves. 
    # E.G. 0:0 is nothing, 0:1 is the first element, and 0:2 is the first 2 elements.
    # This feels slightly more intuitive when negating the start, as to me ':x' reads as get x elements.
    camera.location[:2] = obj.location[:2] # Only want X, Y, want the camera to look down upon the icon not be on the same plane.
    bpy.context.scene.render.filepath = render_directory + obj.name
    bpy.ops.render.render(write_still=True)