// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace PolimorphicJsonSample.Attibute;

public sealed record class YesNoQuestion(string Text, [property: JsonPropertyOrder(2)] YesNo Answer)
  : QuestionBase(Text, QuestionType.YesNo);
