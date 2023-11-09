// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace PolimorphicJsonSample.ContractModel;

public sealed class QuestionJsonTypeInfoResolver : DefaultJsonTypeInfoResolver
{
  private static readonly Dictionary<string, int> _propertyOrderDictionary = new(StringComparer.OrdinalIgnoreCase)
  {
    { nameof(QuestionBase.Text)             , 1 },
    { nameof(MultipleChoiceQuestion.Choices), 2 },
    { nameof(MultipleChoiceQuestion.Answers), 3 },
    { nameof(SingleChoiceQuestion.Answer)   , 3 },
  };

  public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
  {
    JsonTypeInfo jsonTypeInfo = base.GetTypeInfo(type, options);

    if (!TryConfigureTextQuestion(jsonTypeInfo) &&
        !TryConfigureYesNoQuestion(jsonTypeInfo) &&
        !TryConfigureMultipleChoiceQuestion(jsonTypeInfo) &&
        !TryConfigureSingleChoiceQuestion(jsonTypeInfo))
    {
      TryConfigureQuestionBase(jsonTypeInfo);
    }

    return jsonTypeInfo;
  }

  private static JsonPolymorphismOptions? GetjsonPolymorphismOptions() => new()
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

  private static bool TryConfigureQuestionBase(JsonTypeInfo jsonTypeInfo)
  {
    if (jsonTypeInfo.Type != typeof(QuestionBase))
    {
      return false;
    }

    jsonTypeInfo.PolymorphismOptions = GetjsonPolymorphismOptions();
    return true;
  }

  private static bool TryConfigureTextQuestion(JsonTypeInfo jsonTypeInfo)
  {
    if (jsonTypeInfo.Type != typeof(TextQuestion))
    {
      return false;
    }

    for (int i = 0; i < jsonTypeInfo.Properties.Count; i++)
    {
      JsonPropertyInfo property = jsonTypeInfo.Properties[i];

      if (property.Name.Equals(nameof(TextQuestion.Type), StringComparison.OrdinalIgnoreCase))
      {
        property.ShouldSerialize = (_, _) => false;
      }
      else if (property.Name.Equals(nameof(TextQuestion.Text), StringComparison.OrdinalIgnoreCase))
      {
        property.Order = 0;
      }
      else if (property.Name.Equals(nameof(TextQuestion.Answer), StringComparison.OrdinalIgnoreCase))
      {
        property.Order = 1;
      }
    }
    
    return true;
  }

  private static bool TryConfigureYesNoQuestion(JsonTypeInfo jsonTypeInfo)
  {
    if (jsonTypeInfo.Type != typeof(YesNoQuestion))
    {
      return false;
    }

    for (int i = 0; i < jsonTypeInfo.Properties.Count; i++)
    {
      JsonPropertyInfo property = jsonTypeInfo.Properties[i];

      if (property.Name.Equals(nameof(YesNoQuestion.Type), StringComparison.OrdinalIgnoreCase))
      {
        property.ShouldSerialize = (_, _) => false;
      }
      else if (property.Name.Equals(nameof(YesNoQuestion.Text), StringComparison.OrdinalIgnoreCase))
      {
        property.Order = 0;
      }
      else if (property.Name.Equals(nameof(YesNoQuestion.Answer), StringComparison.OrdinalIgnoreCase))
      {
        property.Order = 1;
      }
    }

    return true;
  }

  private static bool TryConfigureMultipleChoiceQuestion(JsonTypeInfo jsonTypeInfo)
  {
    if (jsonTypeInfo.Type != typeof(MultipleChoiceQuestion))
    {
      return false;
    }

    for (int i = 0; i < jsonTypeInfo.Properties.Count; i++)
    {
      JsonPropertyInfo property = jsonTypeInfo.Properties[i];

      if (property.Name.Equals(nameof(MultipleChoiceQuestion.Type), StringComparison.OrdinalIgnoreCase))
      {
        property.ShouldSerialize = (_, _) => false;
      }
      else if (property.Name.Equals(nameof(MultipleChoiceQuestion.Text), StringComparison.OrdinalIgnoreCase))
      {
        property.Order = 0;
      }
      else if (property.Name.Equals(nameof(MultipleChoiceQuestion.Choices), StringComparison.OrdinalIgnoreCase))
      {
        property.Order = 2;
      }
      else if (property.Name.Equals(nameof(MultipleChoiceQuestion.Answers), StringComparison.OrdinalIgnoreCase))
      {
        property.Order = 3;
      }
    }

    return true;
  }

  private static bool TryConfigureSingleChoiceQuestion(JsonTypeInfo jsonTypeInfo)
  {
    if (jsonTypeInfo.Type != typeof(SingleChoiceQuestion))
    {
      return false;
    }

    for (int i = 0; i < jsonTypeInfo.Properties.Count; i++)
    {
      JsonPropertyInfo property = jsonTypeInfo.Properties[i];

      if (property.Name.Equals(nameof(SingleChoiceQuestion.Type), StringComparison.OrdinalIgnoreCase))
      {
        property.ShouldSerialize = (_, _) => false;
      }
      else if (property.Name.Equals(nameof(SingleChoiceQuestion.Text), StringComparison.OrdinalIgnoreCase))
      {
        property.Order = 0;
      }
      else if (property.Name.Equals(nameof(SingleChoiceQuestion.Choices), StringComparison.OrdinalIgnoreCase))
      {
        property.Order = 2;
      }
      else if (property.Name.Equals(nameof(SingleChoiceQuestion.Answer), StringComparison.OrdinalIgnoreCase))
      {
        property.Order = 3;
      }
    }

    return true;
  }
}
