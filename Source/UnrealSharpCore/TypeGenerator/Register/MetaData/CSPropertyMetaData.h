﻿#pragma once
#include "CSMemberMetaData.h"
#include "CSUnrealType.h"

struct UNREALSHARPCORE_API FCSPropertyMetaData : FCSMemberMetaData
{
	virtual ~FCSPropertyMetaData() = default;

	TSharedPtr<FCSUnrealType> Type;
	FName RepNotifyFunctionName;
	int32 ArrayDim = 0;
	EPropertyFlags PropertyFlags;
	ELifetimeCondition LifetimeCondition;

	FString BlueprintSetter;
	FString BlueprintGetter;

	//FTypeMetaData interface implementation
	virtual void SerializeFromJson(const TSharedPtr<FJsonObject>& JsonObject) override;
	//End of implementation

	template<typename T>
	TSharedPtr<T> GetTypeMetaData() const
	{
		return StaticCastSharedPtr<T>(Type);
	}
};
