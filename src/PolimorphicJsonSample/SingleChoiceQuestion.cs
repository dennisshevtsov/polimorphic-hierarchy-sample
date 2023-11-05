// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace PolimorphicJsonSample;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "questionType")]
[JsonDerivedType(typeof(TextQuestion)          , (int)QuestionType.Text          )]
[JsonDerivedType(typeof(YesNoQuestion)         , (int)QuestionType.YesNo         )]
[JsonDerivedType(typeof(MultipleChoiceQuestion), (int)QuestionType.MultipleChoice)]
[JsonDerivedType(typeof(SingleChoiceQuestion)  , (int)QuestionType.SingleChoice  )]
public sealed record class SingleChoiceQuestion(string Text, string[] Choices, string? Answer)
  : QuestionBase(Text, QuestionType.Text);
