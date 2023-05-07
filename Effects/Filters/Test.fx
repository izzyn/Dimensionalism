sampler uImage0 : register(s0);
sampler uImage1 : register(s1);
sampler uImage2 : register(s2);
sampler uImage3 : register(s3);
float3 uColor;
float3 uSecondaryColor;
float2 uScreenResolution;
float2 uScreenPosition;
float2 uTargetPosition;
float2 uDirection;
float uOpacity;
float uTime;
float uIntensity;
float uProgress;
float2 uImageSize1;
float2 uImageSize2;
float2 uImageSize3;
float2 uImageOffset;
float uSaturation;
float4 uSourceRect;
float2 uZoom;

float4 FilterMyShader(float2 coords : TEXCOORD0) : COLOR0
{
    float4 colour = tex2D(uImage0, coords);
    float luminosity = (colour.r + colour.g + colour.b) / 3;
    float wave = 1 - (sin(coords.x + uTime)+1)/2;
    float2 test = float2((coords.x - 0.5f) * (uScreenResolution.y / uScreenResolution.x), (coords.y-0.5f)*(uScreenResolution.y/ uScreenResolution.x));
    if (length(test) < 0.2f) {
        colour.rgb *= uColor;
    }
    return colour;
}

technique Technique1
{
    pass FilterMyShader
    {
        PixelShader = compile ps_2_0 FilterMyShader();
    }
}

