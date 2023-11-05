// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace PolimorphicJsonSample;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(TextQuestion)          , (int)QuestionType.Text          )]
[JsonDerivedType(typeof(YesNoQuestion)         , (int)QuestionType.YesNo         )]
[JsonDerivedType(typeof(MultipleChoiceQuestion), (int)QuestionType.MultipleChoice)]
[JsonDerivedType(typeof(SingleChoiceQuestion)  , (int)QuestionType.SingleChoice  )]
public abstract record class QuestionBase(
  [property: JsonPropertyOrder(1)] string Text,
  [property: JsonIgnore          ] QuestionType Type);
