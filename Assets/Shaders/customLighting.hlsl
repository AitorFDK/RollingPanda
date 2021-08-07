
#ifndef CUSTOM_LIGHTING_INCLUDED
	#define CUSTOM_LIGHTING_INCLUDED
	
	// #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
	// #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Shadows.hlsl"

	void MainLight_float (float3 WorldPos, out float3 Direction, out float3 Color,
	out float DistanceAtten, out float ShadowAtten){
		
		#ifdef SHADERGRAPH_PREVIEW
			Direction = normalize(float3(1,1,-0.4));
			Color = float4(1,1,1,1);
			DistanceAtten = 1;
			ShadowAtten = 1;
		#else
			#ifdef LIGHTWEIGHT_LIGHTING_INCLUDED
				float4 shadowCoord;
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
					shadowCoord = input.shadowCoord;
				#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
					shadowCoord = TransformWorldToShadowCoord(positionWS);
				#else
					shadowCoord = float4(0, 0, 0, 0);
				#endif

				Light mainLight = GetMainLight(shadowCoord); 
				
				
				Direction = mainLight.direction;
				Color = mainLight.color;
				DistanceAtten = mainLight.distanceAttenuation;
				ShadowAtten = mainLight.shadowAttenuation;
			#else
				Direction = float3(0, 0, 0);
				Color = float4(0, 0, 0, 0);
				DistanceAtten = 1;
				ShadowAtten = 1;
			#endif
		#endif

	}

	// Alternative method, which bypasses keywords
	void MainLightShadows_float (float3 WorldPos, out float3 Direction, out float3 Color,
	out float DistanceAtten, out float ShadowAtten){

		#ifdef SHADERGRAPH_PREVIEW
			Direction = normalize(float3(1,1,-0.4));
			Color = float4(1,1,1,1);
			DistanceAtten = 1;
			ShadowAtten = 1;
		#else
			#ifdef LIGHTWEIGHT_LIGHTING_INCLUDED
				Light mainLight = GetMainLight();
				Direction = mainLight.direction;
				Color = mainLight.color;
				DistanceAtten = mainLight.distanceAttenuation;

				float4 shadowCoord = TransformWorldToShadowCoord(WorldPos);
				// or if cascades are needed :
				// half cascadeIndex = ComputeCascadeIndex(WorldPos);
				// float4 shadowCoord = mul(_MainLightWorldToShadow[cascadeIndex], float4(WorldPos, 1.0));

				ShadowSamplingData shadowSamplingData = GetMainLightShadowSamplingData();
				float shadowStrength = GetMainLightShadowStrength();
				ShadowAtten = SampleShadowmap(shadowCoord, TEXTURE2D_ARGS(_MainLightShadowmapTexture, sampler_MainLightShadowmapTexture), shadowSamplingData, shadowStrength, false);
			#else
				Direction = float3(0, 0, 0);
				Color = float4(0, 0, 0, 0);
				DistanceAtten = 1;
				ShadowAtten = 1;
			#endif
		#endif
	}

#endif // CUSTOM_LIGHTING_INCLUDED