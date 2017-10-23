float4 VS(float4 input : POSITION0) : POSITION0
{
	return input;
}

struct PSO
{
	float4 Albedo : COLOR0;
	float4 Normals : COLOR1;
};

PSO PS(float4 input : POSITION0)
{
	PSO output;
	output.Albedo = float4(1, 0, 0, 1);
	output.Normals = float4(0, 1, 0, 1);
	return output;
}

technique Default
{
	pass p0
	{
		VertexShader = compile vs_3_0 VS();
		PixelShader = compile ps_3_0 PS();
	}
}