# PATH natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## ADD_NAVMESH_BLOCKING_OBJECT

```c
int ADD_NAVMESH_BLOCKING_OBJECT(float p0, float p1, float p2, float p3, float p4, float p5, float p6, BOOL p7, Any p8)  // 0xFCD5C8E06E502F5A
```

build 323

## ADD_NAVMESH_REQUIRED_REGION

```c
void ADD_NAVMESH_REQUIRED_REGION(float x, float y, float radius)  // 0x387EAD7EE42F6685
```

build 323

## ADJUST_AMBIENT_PED_SPAWN_DENSITIES_THIS_FRAME

```c
void ADJUST_AMBIENT_PED_SPAWN_DENSITIES_THIS_FRAME(Any p0, Any p1, Any p2, Any p3, Any p4, Any p5, Any p6)  // 0xAA76052DDA9BFC3E
```

build 323

## ARE_ALL_NAVMESH_REGIONS_LOADED

```c
BOOL ARE_ALL_NAVMESH_REGIONS_LOADED()  // 0x8415D95B194A3AEA
```

build 323

## ARE_NODES_LOADED_FOR_AREA

```c
BOOL ARE_NODES_LOADED_FOR_AREA(float x1, float y1, float x2, float y2)  // 0xF7B79A50B905A30D
```

build 323 · old names: `_ARE_PATH_NODES_LOADED_IN_AREA`

## CALCULATE_TRAVEL_DISTANCE_BETWEEN_POINTS

```c
float CALCULATE_TRAVEL_DISTANCE_BETWEEN_POINTS(float x1, float y1, float z1, float x2, float y2, float z2)  // 0xADD95C7005C4A197
```

build 323

> Calculates the travel distance between a set of points.
> 
> Doesn't seem to correlate with distance on gps sometimes.
> This function returns the value 100000.0 over long distances, seems to be a failure mode result, potentially occurring when not all path nodes are loaded into pathfind.

## CLEAR_GPS_DISABLED_ZONE_AT_INDEX

```c
void CLEAR_GPS_DISABLED_ZONE_AT_INDEX(int index)  // 0x2801D0012266DF07
```

build 323 · old names: `_CLEAR_GPS_DISABLED_ZONE_AT_INDEX`

> Clears a disabled GPS route area from a certain index previously set using `SET_GPS_DISABLED_ZONE_AT_INDEX`.

## DISABLE_NAVMESH_IN_AREA

```c
void DISABLE_NAVMESH_IN_AREA(float x1, float y1, float z1, float x2, float y2, float z2, BOOL toggle)  // 0x4C8872D8CDBE1B8B
```

build 323

> Set toggle true to disable navmesh.
> Set toggle false to enable navmesh.

## DOES_NAVMESH_BLOCKING_OBJECT_EXIST

```c
BOOL DOES_NAVMESH_BLOCKING_OBJECT_EXIST(Any p0)  // 0x0EAEB0DB4B132399
```

build 323

## GENERATE_DIRECTIONS_TO_COORD

```c
int GENERATE_DIRECTIONS_TO_COORD(float x, float y, float z, BOOL p3, int* direction, float* p5, float* distToNxJunction)  // 0xF90125F1F79ECDF8
```

build 323

> p3 is 0 in the only game script occurrence (trevor3) but 1 doesn't seem to make a difference
> 
> distToNxJunction seems to be the distance in metres * 10.0f
> 
> direction:
> 0 = This happens randomly during the drive for seemingly no reason but if you consider that this native is only used in trevor3, it seems to mean "Next frame, stop whatever's being said and tell the player the direction."
> 1 = Route is being calculated or the player is going in the wrong direction
> 2 = Please Proceed the Highlighted Route
> 3 = In (distToNxJunction) Turn Left
> 4 = In (distToNxJunction) Turn Right
> 5 = In (distToNxJunction) Keep Straight
> 6 = In (distToNxJunction) Turn Sharply To The Left
> 7 = In (distToNxJunction) Turn Sharply To The Right
> 8 = Route is being recalculated or the navmesh is confusing. This happens randomly during the drive but consistently at {2044.0358, 2996.6116, 44.9717} if you face towards the bar and the route needs you to turn right. In that particular case, it could be a bug with how the turn appears to be 270 deg. CCW instead of "right." Either way, this seems to be the engine saying "I don't know the route right now."
> 
> return value set to 0 always

## GET_APPROX_FLOOR_FOR_AREA

```c
float GET_APPROX_FLOOR_FOR_AREA(float x1, float y1, float x2, float y2)  // 0x3599D741C9AC6310
```

build 323 · old names: `_GET_HEIGHTMAP_BOTTOM_Z_FOR_AREA`

> Returns CGameWorldHeightMap's minimum Z among all grid nodes that intersect with the specified rectangle.

## GET_APPROX_FLOOR_FOR_POINT

```c
float GET_APPROX_FLOOR_FOR_POINT(float x, float y)  // 0x336511A34F2E5185
```

build 323 · old names: `_GET_HEIGHTMAP_BOTTOM_Z_FOR_POSITION`

> Returns CGameWorldHeightMap's minimum Z value at specified point (grid node).

## GET_APPROX_HEIGHT_FOR_AREA

```c
float GET_APPROX_HEIGHT_FOR_AREA(float x1, float y1, float x2, float y2)  // 0x8ABE8608576D9CE3
```

build 323 · old names: `_GET_HEIGHTMAP_TOP_Z_FOR_AREA`

> Returns CGameWorldHeightMap's maximum Z among all grid nodes that intersect with the specified rectangle.

## GET_APPROX_HEIGHT_FOR_POINT

```c
float GET_APPROX_HEIGHT_FOR_POINT(float x, float y)  // 0x29C24BFBED8AB8FB
```

build 323 · old names: `_GET_HEIGHTMAP_TOP_Z_FOR_POSITION`

> Returns CGameWorldHeightMap's maximum Z value at specified point (grid node).

## GET_CLOSEST_MAJOR_VEHICLE_NODE

```c
BOOL GET_CLOSEST_MAJOR_VEHICLE_NODE(float x, float y, float z, Vector3* outPosition, float unknown1, float unknown2)  // 0x2EABE3B06F58C1BE
```

build 323

> Get the closest vehicle node to a given position.

## GET_CLOSEST_ROAD

```c
BOOL GET_CLOSEST_ROAD(float x, float y, float z, float p3, int p4, Vector3* p5, Vector3* p6, Any* p7, Any* p8, float* p9, BOOL p10)  // 0x132F52BBA570FE92
```

build 323

> p1 seems to be always 1.0f in the scripts

## GET_CLOSEST_VEHICLE_NODE

```c
BOOL GET_CLOSEST_VEHICLE_NODE(float x, float y, float z, Vector3* outPosition, int nodeFlags, float p5, float p6)  // 0x240A18690AE96513
```

build 323

> https://gtaforums.com/topic/843561-pathfind-node-types

## GET_CLOSEST_VEHICLE_NODE_WITH_HEADING

```c
BOOL GET_CLOSEST_VEHICLE_NODE_WITH_HEADING(float x, float y, float z, Vector3* outPosition, float* outHeading, int nodeType, float p6, float p7)  // 0xFF071FB798B803B0
```

build 323

> p5, p6 and p7 seems to be about the same as p4, p5 and p6 for GET_CLOSEST_VEHICLE_NODE. p6 and/or p7 has something to do with finding a node on the same path/road and same direction(at least for this native, something to do with the heading maybe). Edit this when you find out more.
> 
> nodeType: 0 = main roads, 1 = any dry path, 3 = water
> p6 is always 3.0
> p7 is always 0
> 
> https://gtaforums.com/topic/843561-pathfind-node-types
> 
> Example of usage, moving vehicle to closest path/road:
> Vector3 coords = ENTITY::GET_ENTITY_COORDS(playerVeh, true);
> Vector3 closestVehicleNodeCoords; 
> float roadHeading; 
> PATHFIND::GET_CLOSEST_VEHICLE_NODE_WITH_HEADING(coords.x, coords.y, coords.z, &closestVehicleNodeCoords, &roadHeading, 1, 3, 0); 
> ENTITY::SET_ENTITY_HEADING(playerVeh, roadHeading);
> ENTITY::SET_ENTITY_COORDS(playerVeh, closestVehicleNodeCoords.x, closestVehicleNodeCoords.y, closestVehicleNodeCoords.z, 1, 0, 0, 1);
> VEHICLE::SET_VEHICLE_ON_GROUND_PROPERLY(playerVeh);
> 
> ------------------------------------------------------------------
> C# Example (ins1de) : https://pastebin.com/fxtMWAHD

## GET_GPS_BLIP_ROUTE_FOUND

```c
BOOL GET_GPS_BLIP_ROUTE_FOUND()  // 0x869DAACBBE9FA006
```

build 323

## GET_GPS_BLIP_ROUTE_LENGTH

```c
int GET_GPS_BLIP_ROUTE_LENGTH()  // 0xBBB45C3CF5C8AA85
```

build 323

## GET_NEXT_GPS_DISABLED_ZONE_INDEX

```c
int GET_NEXT_GPS_DISABLED_ZONE_INDEX()  // 0xD3A6A0EF48823A8C
```

build 323

> Gets the next zone that has been disabled using SET_GPS_DISABLED_ZONE_AT_INDEX.

## GET_NTH_CLOSEST_VEHICLE_NODE

```c
BOOL GET_NTH_CLOSEST_VEHICLE_NODE(float x, float y, float z, int nthClosest, Vector3* outPosition, int nodeFlags, float unknown1, float unknown2)  // 0xE50E52416CCF948B
```

build 323

## GET_NTH_CLOSEST_VEHICLE_NODE_FAVOUR_DIRECTION

```c
BOOL GET_NTH_CLOSEST_VEHICLE_NODE_FAVOUR_DIRECTION(float x, float y, float z, float desiredX, float desiredY, float desiredZ, int nthClosest, Vector3* outPosition, float* outHeading, int nodeFlags, float p10, float p11)  // 0x45905BE8654AE067
```

build 323

> See https://gtaforums.com/topic/843561-pathfind-node-types for node type info. 0 = paved road only, 1 = any road, 3 = water
> 
> p10 always equals 3.0
> p11 always equals 0

## GET_NTH_CLOSEST_VEHICLE_NODE_ID

```c
int GET_NTH_CLOSEST_VEHICLE_NODE_ID(float x, float y, float z, int nth, int nodeFlags, float p5, float p6)  // 0x22D7275A79FE8215
```

build 323

> Returns the id.

## GET_NTH_CLOSEST_VEHICLE_NODE_ID_WITH_HEADING

```c
int GET_NTH_CLOSEST_VEHICLE_NODE_ID_WITH_HEADING(float x, float y, float z, int nthClosest, float* outHeading, int* outNumLanes, int nodeFlags, float zMeasureMult, float zTolerance)  // 0x6448050E9C2A7207
```

build 323

## GET_NTH_CLOSEST_VEHICLE_NODE_WITH_HEADING

```c
BOOL GET_NTH_CLOSEST_VEHICLE_NODE_WITH_HEADING(float x, float y, float z, int nthClosest, Vector3* outPosition, float* outHeading, int* outNumLanes, int nodeFlags, float unknown3, float unknown4)  // 0x80CA6A8B6C094CC4
```

build 323

> Get the nth closest vehicle node and its heading.

## GET_NUM_NAVMESHES_EXISTING_IN_AREA

```c
int GET_NUM_NAVMESHES_EXISTING_IN_AREA(float x1, float y1, float z1, float x2, float y2, float z2)  // 0x01708E8DD3FF8C65
```

build 323

## GET_POS_ALONG_GPS_TYPE_ROUTE

```c
BOOL GET_POS_ALONG_GPS_TYPE_ROUTE(Vector3* result, BOOL p1, float p2, int p3)  // 0xF3162836C28F9DA5
```

build 505 · old names: `GET_GPS_WAYPOINT_ROUTE_END`

> p3 can be 0, 1 or 2.

## GET_POSITION_BY_SIDE_OF_ROAD

```c
BOOL GET_POSITION_BY_SIDE_OF_ROAD(float x, float y, float z, int p3, Vector3* outPosition)  // 0x16F46FB18C8009E4
```

build 323 · old names: `_GET_POINT_ON_ROAD_SIDE`

## GET_RANDOM_VEHICLE_NODE

```c
BOOL GET_RANDOM_VEHICLE_NODE(float x, float y, float z, float radius, BOOL p4, BOOL p5, BOOL p6, Vector3* outPosition, int* nodeId)  // 0x93E0DB8440B73A7D
```

build 323

## GET_ROAD_BOUNDARY_USING_HEADING

```c
BOOL GET_ROAD_BOUNDARY_USING_HEADING(float x, float y, float z, float heading, Vector3* outPosition)  // 0xA0F8A7517A273C05
```

build 463 · old names: `_GET_ROAD_SIDE_POINT_WITH_HEADING`

## GET_SAFE_COORD_FOR_PED

```c
BOOL GET_SAFE_COORD_FOR_PED(float x, float y, float z, BOOL onGround, Vector3* outPosition, int flags)  // 0xB61C8E878A4199CA
```

build 323

> Flags are:
> 1 = 1 = B02_IsFootpath
> 2 = 4 = !B15_InteractionUnk
> 4 = 0x20 = !B14_IsInterior
> 8 = 0x40 = !B07_IsWater
> 16 = 0x200 = B17_IsFlatGround
> When onGround == true outPosition is a position located on the nearest pavement.
> 
> When a safe coord could not be found the result of a function is false and outPosition == Vector3.Zero.
> 
> In the scripts these flags are used: 0, 14, 12, 16, 20, 21, 28. 0 is most commonly used, then 16. 
> 
> 16 works for me, 0 crashed the script.

## GET_SPAWN_COORDS_FOR_VEHICLE_NODE

```c
void GET_SPAWN_COORDS_FOR_VEHICLE_NODE(int nodeAddress, float towardsCoorsX, float towardsCoorsY, float towardsCoorsZ, Vector3* centrePoint, float* heading)  // 0x809549AFC7AEC597
```

build 2944

## GET_STREET_NAME_AT_COORD

```c
void GET_STREET_NAME_AT_COORD(float x, float y, float z, Hash* streetName, Hash* crossingRoad)  // 0x2EB41072B4C1E4C0
```

build 323

> Determines the name of the street which is the closest to the given coordinates.
> 
> x,y,z - the coordinates of the street
> streetName - returns a hash to the name of the street the coords are on
> crossingRoad - if the coordinates are on an intersection, a hash to the name of the crossing road
> 
> Note: the names are returned as hashes, the strings can be returned using the function HUD::GET_STREET_NAME_FROM_HASH_KEY.

## GET_VEHICLE_NODE_IS_GPS_ALLOWED

```c
BOOL GET_VEHICLE_NODE_IS_GPS_ALLOWED(int nodeID)  // 0xA2AE5C478B96E3B6
```

build 323 · old names: `_GET_SUPPORTS_GPS_ROUTE_FLAG`

> Returns false for nodes that aren't used for GPS routes.
> Example:
> Nodes in Fort Zancudo and LSIA are false

## GET_VEHICLE_NODE_IS_SWITCHED_OFF

```c
BOOL GET_VEHICLE_NODE_IS_SWITCHED_OFF(int nodeID)  // 0x4F5070AA58F69279
```

build 323 · old names: `_GET_IS_SLOW_ROAD_FLAG`

> Returns true when the node is Offroad. Alleys, some dirt roads, and carparks return true.
> Normal roads where plenty of Peds spawn will return false

## GET_VEHICLE_NODE_POSITION

```c
void GET_VEHICLE_NODE_POSITION(int nodeId, Vector3* outPosition)  // 0x703123E5E7D429C2
```

build 323

> Calling this with an invalid node id, will crash the game.
> Note that IS_VEHICLE_NODE_ID_VALID simply checks if nodeId is not zero. It does not actually ensure that the id is valid.
> Eg. IS_VEHICLE_NODE_ID_VALID(1) will return true, but will crash when calling GET_VEHICLE_NODE_POSITION().

## GET_VEHICLE_NODE_PROPERTIES

```c
BOOL GET_VEHICLE_NODE_PROPERTIES(float x, float y, float z, int* density, int* flags)  // 0x0568566ACBB5DEDC
```

build 323

> Gets the density and flags of the closest node to the specified position.
> Density is a value between 0 and 15, indicating how busy the road is.
> Flags is a bit field.

## IS_NAVMESH_LOADED_IN_AREA

```c
BOOL IS_NAVMESH_LOADED_IN_AREA(float x1, float y1, float z1, float x2, float y2, float z2)  // 0xF813C7E63F9062A5
```

build 323

> Returns whether navmesh for the region is loaded. The region is a rectangular prism defined by it's top left deepest corner to it's bottom right shallowest corner.
> 
> If you can re-word this so it makes more sense, please do. I'm horrible with words sometimes...

## IS_NAVMESH_REQUIRED_REGION_IN_USE

```c
BOOL IS_NAVMESH_REQUIRED_REGION_IN_USE()  // 0x705A844002B39DC0
```

build 944 · old names: `_IS_NAVMESH_REQUIRED_REGION_OWNED_BY_ANY_THREAD`

## IS_POINT_ON_ROAD

```c
BOOL IS_POINT_ON_ROAD(float x, float y, float z, Vehicle vehicle)  // 0x125BF4ABFC536B09
```

build 323

> Gets a value indicating whether the specified position is on a road.
> The vehicle parameter is not implemented (ignored).

## IS_VEHICLE_NODE_ID_VALID

```c
BOOL IS_VEHICLE_NODE_ID_VALID(int vehicleNodeId)  // 0x1EAF30FCFBF5AF74
```

build 323

> Returns true if the id is non zero.

## LOAD_ALL_PATH_NODES

```c
BOOL LOAD_ALL_PATH_NODES(BOOL bLoadAll)  // 0xC2AB6BFE34E92F8B
```

build 2802

> Loads/unloads all path nodes on the map.
> Returns true if all nodes are loaded (effectively ARE_NODES_LOADED_FOR_AREA for the entire map).
> 
> Note: this native was removed in build 1180 but returned in build 2802.

## REMOVE_NAVMESH_BLOCKING_OBJECT

```c
void REMOVE_NAVMESH_BLOCKING_OBJECT(Any p0)  // 0x46399A7895957C0E
```

build 323

## REMOVE_NAVMESH_REQUIRED_REGIONS

```c
void REMOVE_NAVMESH_REQUIRED_REGIONS()  // 0x916F0A3CDEC3445E
```

build 323

## REQUEST_PATH_NODES_IN_AREA_THIS_FRAME

```c
BOOL REQUEST_PATH_NODES_IN_AREA_THIS_FRAME(float x1, float y1, float x2, float y2)  // 0x07FB139B592FA687
```

build 323 · old names: `REQUEST_PATHS_PREFER_ACCURATE_BOUNDINGSTRUCT`

> Used internally for long range tasks

## SET_ALLOW_STREAM_HEIST_ISLAND_NODES

```c
void SET_ALLOW_STREAM_HEIST_ISLAND_NODES(int type)  // 0xF74B1FFA4A15FBEA
```

build 2189 · old names: `_SET_AI_GLOBAL_PATH_NODES_TYPE`

> Activates Cayo Perico path nodes if passed `1`. GPS navigation will start working, maybe more stuff will change, not sure. It seems if you try to unload (pass `0`) when close to the island, your game might crash.

## SET_ALLOW_STREAM_PROLOGUE_NODES

```c
void SET_ALLOW_STREAM_PROLOGUE_NODES(BOOL toggle)  // 0x228E5C6AD4D74BFD
```

build 323 · old names: `SET_ALL_PATHS_CACHE_BOUNDINGSTRUCT`

## SET_AMBIENT_PED_RANGE_MULTIPLIER_THIS_FRAME

```c
void SET_AMBIENT_PED_RANGE_MULTIPLIER_THIS_FRAME(float multiplier)  // 0x0B919E1FB47CC4E0
```

build 323

## SET_GPS_DISABLED_ZONE

```c
void SET_GPS_DISABLED_ZONE(float x1, float y1, float z1, float x2, float y2, float z3)  // 0xDC20483CD3DD5201
```

build 323

## SET_GPS_DISABLED_ZONE_AT_INDEX

```c
void SET_GPS_DISABLED_ZONE_AT_INDEX(float x1, float y1, float z1, float x2, float y2, float z2, int index)  // 0xD0BC1C6FB18EE154
```

build 323

> Disables the GPS route displayed on the minimap while within a certain zone (area). When in a disabled zone and creating a waypoint, the GPS route is not shown on the minimap until you are outside of the zone. When disabled, the direct distance is shown on minimap opposed to distance to travel. Seems to only work before setting a waypoint.
> You can clear the disabled zone with CLEAR_GPS_DISABLED_ZONE_AT_INDEX.
> 
> **Setting a waypoint at the same coordinate:**
> Disabled Zone: https://i.imgur.com/vsxkvjC.png
> Enabled Zone (normal): https://i.imgur.com/OUZYLWL.png

## SET_IGNORE_NO_GPS_FLAG

```c
void SET_IGNORE_NO_GPS_FLAG(BOOL toggle)  // 0x72751156E7678833
```

build 323

## SET_IGNORE_NO_GPS_FLAG_UNTIL_FIRST_NORMAL_NODE

```c
void SET_IGNORE_NO_GPS_FLAG_UNTIL_FIRST_NORMAL_NODE(BOOL toggle)  // 0x1FC289A0C3FF470F
```

build 323 · old names: `_SET_IGNORE_SECONDARY_ROUTE_NODES`

> See: SET_BLIP_ROUTE

## SET_PED_PATHS_BACK_TO_ORIGINAL

```c
void SET_PED_PATHS_BACK_TO_ORIGINAL(float x1, float y1, float z1, float x2, float y2, float z2, Any p6)  // 0xE04B48F2CC926253
```

build 323

> p6 is always 0

## SET_PED_PATHS_IN_AREA

```c
void SET_PED_PATHS_IN_AREA(float x1, float y1, float z1, float x2, float y2, float z2, BOOL p6, Any p7)  // 0x34F060F4BF92E018
```

build 323

## SET_ROADS_BACK_TO_ORIGINAL

```c
void SET_ROADS_BACK_TO_ORIGINAL(float p0, float p1, float p2, float p3, float p4, float p5, Any p6)  // 0x1EE7063B80FFC77C
```

build 323

## SET_ROADS_BACK_TO_ORIGINAL_IN_ANGLED_AREA

```c
void SET_ROADS_BACK_TO_ORIGINAL_IN_ANGLED_AREA(float x1, float y1, float z1, float x2, float y2, float z2, float width, Any p7)  // 0x0027501B9F3B407E
```

build 323

> See IS_POINT_IN_ANGLED_AREA for the definition of an angled area.
> bool p7 - always 1

## SET_ROADS_IN_ANGLED_AREA

```c
void SET_ROADS_IN_ANGLED_AREA(float x1, float y1, float z1, float x2, float y2, float z2, float width, BOOL unknown1, BOOL unknown2, BOOL unknown3)  // 0x1A5AA1208AF5DB59
```

build 323

> unknown3 is related to `SEND_SCRIPT_WORLD_STATE_EVENT > CNetworkRoadNodeWorldStateData` in networked environments.
> See IS_POINT_IN_ANGLED_AREA for the definition of an angled area.

## SET_ROADS_IN_AREA

```c
void SET_ROADS_IN_AREA(float x1, float y1, float z1, float x2, float y2, float z2, BOOL nodeEnabled, BOOL unknown2)  // 0xBF1A602B5BA52FEE
```

build 323

> When nodeEnabled is set to false, all nodes in the area get disabled.
> `GET_VEHICLE_NODE_IS_SWITCHED_OFF` returns true afterwards.
> If it's true, `GET_VEHICLE_NODE_IS_SWITCHED_OFF` returns false.

## UPDATE_NAVMESH_BLOCKING_OBJECT

```c
void UPDATE_NAVMESH_BLOCKING_OBJECT(Any p0, float p1, float p2, float p3, float p4, float p5, float p6, float p7, Any p8)  // 0x109E99373F290687
```

build 323

