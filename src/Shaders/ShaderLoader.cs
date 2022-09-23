using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using EsportGraphics.src.EGraphics;
using DuckGame;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using Microsoft.Xna.Framework.Graphics;

namespace EsportGraphics.src.Shaders
{
    public static class ShaderLoader
    {
        public static Dictionary<string, byte[]> shadersCodes = new();
        public static Dictionary<string, MTEffect> mtEffects = new();
        public static void Load()
        {
            EffectProcessor processor = new EffectProcessor();
            var effect = processor.Process(new EffectContent { EffectCode = ColorFX() }, new MyContext());

            string name = "color";
            shadersCodes.Add(name, effect.GetEffectCode());
            mtEffects.Add(name, new MTEffect(new Effect(Graphics.device, ShaderLoader.shadersCodes[name]), name));

        }
        private static string ColorFX()
        {
            string code =

@"sampler sprite;
float greyStyle;
float4 overlay_color;
float4 black = float4(0, 0, 0, 1);
float4 PixelShaderFunction(float2 uv: TEXCOORD0, float4 c: COLOR0) : COLOR0
{
    float4 col = tex2D(sprite, uv);
    
    if (all(col == black))
    {
        return col;
    }

    if (greyStyle == 1)
    {
        col.rgb = (col.r + col.g + col.b) / 3;
    }

    if (col.a != 0)
    {
        col.r = (overlay_color.r + col.r) / 2;
        col.g = (overlay_color.g + col.g) / 2;
        col.b = (overlay_color.b + col.b) / 2;   
    }
    return col;
}

technique Test
{
    pass Pass1
    {
        PixelShader = compile ps_2_0 PixelShaderFunction();
    }
}
";
            return code;
        }
    }
}
