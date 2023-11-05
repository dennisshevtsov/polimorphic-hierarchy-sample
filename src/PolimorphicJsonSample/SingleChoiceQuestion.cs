// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace PolimorphicJsonSample;

public sealed record class SingleChoiceQuestion(
  string Text,
  [property: JsonPropertyOrder(2)] string[] Choices,
  [property: JsonPropertyOrder(3)] string? Answer)
  : QuestionBase(Text, QuestionType.SingleChoice);
