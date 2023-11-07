// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace PolimorphicJsonSample.ContractModel;

public sealed class QuestionJsonTypeInfoResolver : DefaultJsonTypeInfoResolver
{
  public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
  {
    JsonTypeInfo jsonTypeInfo = base.GetTypeInfo(type, options);

    if (jsonTypeInfo.Type != typeof(QuestionBase))
    {
      return jsonTypeInfo;
    }

    jsonTypeInfo.PolymorphismOptions = new JsonPolymorphismOptions
    {
      TypeDiscriminatorPropertyName = "type",
      DerivedTypes =
      {
        new JsonDerivedType
        (
          derivedType      : typeof(TextQuestion),
          typeDiscriminator: (int)QuestionType.Text
        ),
        new JsonDerivedType
        (
          derivedType      : typeof(YesNoQuestion),
          typeDiscriminator: (int)QuestionType.YesNo
        ),
        new JsonDerivedType
        (
          derivedType      : typeof(MultipleChoiceQuestion),
          typeDiscriminator: (int)QuestionType.MultipleChoice
        ),
        new JsonDerivedType
        (
          derivedType      : typeof(SingleChoiceQuestion),
          typeDiscriminator: (int)QuestionType.SingleChoice
        ),
      },
    };

    return jsonTypeInfo;
  }
}
