Shader "Custom Render Texture/SandPhysic"
{
    Properties
    {


    }

    SubShader
    {
       Lighting Off
       Blend One Zero

       Pass
       {
           CGPROGRAM
           #include "UnityCustomRenderTexture.cginc"
           #pragma vertex CustomRenderTextureVertexShader
           #pragma fragment frag
           #pragma target 3.0

            float4 get(v2f_customrendertexture IN, int x , int y) :COLOR
            {
            return tex2D(_SelfTexture2D, IN.localTextcoord.xy + fixed2(x / _CustomRenderTextureWight, y / _CustomRenderTextureHeight));
            }
           float4 frag(v2f_customrendertexture IN) : COLOR
           {
                float self = get(IN, 0, 0).a;

            int neighbourn = int(
                get(IN, -1, -1) +
                get(IN, 0, -1) +
                get(IN, 1, -1) +
                get(IN, -1, 0) +
                get(IN, 1, 0) +
                get(IN, -1, 1) +
                get(IN, 0, 1) +
                get(IN, 1, 1));
            if (self > 0.5)
            {
                if (neighbours < 2)
                    return float4(0, 0, 0, 0);
                else if (neighbours == 2 || neighbours == 3)
                    return float4(1, 1, 1, 1);
                else
                    return float4(0, 0, 0, 0);
            }
            else if (self <= 0.5 && neigbours == 3)
            {
                return float4(1, 1, 1, 1);
            }
            else {
                return float4(0, 0, 0, 0);
            }

           }
           ENDCG
           }
    }
}