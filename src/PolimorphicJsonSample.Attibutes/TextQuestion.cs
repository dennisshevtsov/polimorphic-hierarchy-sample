// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace PolimorphicJsonSample.Attibutes;

public sealed record class TextQuestion(string Text, [property: JsonPropertyOrder(2)] string? Answer)
  : QuestionBase(Text, QuestionType.Text);
