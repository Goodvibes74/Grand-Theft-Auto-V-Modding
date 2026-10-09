// invoke<R>(hash, args...): calls a native function by its 64-bit hash.
// natives.hpp wraps every native in a named function built on this, so you rarely call it yourself.

#pragma once

#include <cstring>
#include <type_traits>

#include "main.h"
#include "types.h"

namespace shv_detail
{
	template <typename T>
	inline void push(T value)
	{
		static_assert(sizeof(T) <= sizeof(UINT64), "native arguments must fit in 8 bytes");
		UINT64 slot = 0;
		std::memcpy(&slot, &value, sizeof(T));
		nativePush64(slot);
	}

	// A Vector3 passed by value takes three argument slots: x, y and z.
	inline void push(const Vector3& v)
	{
		push(v.x);
		push(v.y);
		push(v.z);
	}
}

template <typename R, typename... Args>
inline R invoke(UINT64 hash, Args... args)
{
	nativeInit(hash);
	(shv_detail::push(args), ...);
	if constexpr (std::is_void_v<R>)
		nativeCall();
	else
		return *reinterpret_cast<R*>(nativeCall());
}
