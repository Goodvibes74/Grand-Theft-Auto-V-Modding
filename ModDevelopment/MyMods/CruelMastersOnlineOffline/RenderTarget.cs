using System;
using GTA;
using GTA.Native;

namespace CruelMastersOnlineOffline;

public class RenderTarget : IDisposable
{
	public int Handle;

	public string Name;

	public Model Model;

	public bool Valid => Handle != -1;

	public RenderTarget(string name, Model model, bool create = true)
	{
		Name = name;
		Model = model;
		if (create)
		{
			Create();
		}
	}

	public void Create()
	{
		CreateNamedRenderTargetForModel(Name, Model);
	}

	public void Release()
	{
		Function.Call(Hash.RELEASE_NAMED_RENDERTARGET, Name);
	}

	public static int CreateNamedRenderTargetForModel(string name, Model model)
	{
		int result = 0;
		if (!Function.Call<bool>(Hash.IS_NAMED_RENDERTARGET_REGISTERED, name))
		{
			Function.Call<bool>(Hash.REGISTER_NAMED_RENDERTARGET, name, 0);
		}
		if (!Function.Call<bool>(Hash.IS_NAMED_RENDERTARGET_LINKED, model.Hash))
		{
			Function.Call(Hash.LINK_NAMED_RENDERTARGET, model.Hash);
		}
		if (Function.Call<bool>(Hash.IS_NAMED_RENDERTARGET_REGISTERED, name))
		{
			result = Function.Call<int>(Hash.GET_NAMED_RENDERTARGET_RENDER_ID, name);
		}
		return result;
	}

	public static void DeleteNamedRenderTargetForModel(string name)
	{
		if (Function.Call<bool>(Hash.IS_NAMED_RENDERTARGET_REGISTERED, name))
		{
			Function.Call(Hash.RELEASE_NAMED_RENDERTARGET, name);
		}
	}

	public static void DrawOnRenderTarget(int renderTarget, int scaleform)
	{
		Function.Call(Hash.SET_TEXT_RENDER_ID, renderTarget);
		Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
		Function.Call(Hash.DRAW_SCALEFORM_MOVIE, scaleform, 0.4f, 0.36f, 0.94f, 0.9f, 255, 255, 255, 255);
		Function.Call(Hash.SET_TEXT_RENDER_ID, 1);
	}

	public static void SetScaleformFitRenderTarget(int scaleform, bool toggle)
	{
		Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, scaleform, toggle);
	}

	public void Dispose()
	{
		Release();
	}
}
