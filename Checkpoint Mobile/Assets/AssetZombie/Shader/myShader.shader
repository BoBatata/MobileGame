Shader "myShader" 
{
	
	Properties 
	{
		_illuminCol ("Self-Ilumination color (RGB)", Color) = (1,1,1,1)
		_Color("Base Color", Color) = (1,1,1,0)
		_SpecColor("Spec Color", Color) = (1,1,1,1)
		_Emission("Emmisive Color", Color) = (0,0,0,0)
		_Shininess ("Shininess", Range (0.0, 1)) = 0.7				
		_MainTex ("Base (RGB)", 2D) = "white" {}				
	}		
	
	SubShader 
	{
		Pass
		{		
			Material
			{
				Diffuse[_Color]			
				Ambient[_Color]
				Shininess[_Shininess]
				Specular[_SpecColor]
				Emission[_Emission]				
			}
				
			Lighting On
			SeparateSpecular On								
			
			// Self-Ilumination
			SetTexture[_MainTex]
			{
				constantColor[_illuminCol]
				combine constant lerp(texture) previous				
			}							
			
			// Diffuse + Self-Ilumination
			SetTexture[_MainTex]
			{				
				combine primary * texture
			}					
		}					
		
		Pass
		{			
			Color(0,0,0,0)
			Cull Front		
		}
	}
			

		
	 
	
}
