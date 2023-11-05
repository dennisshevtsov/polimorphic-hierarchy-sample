// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace PolimorphicJsonSample;

public sealed record class YesNoQuestion(string Text, YesNo Answer)
  : QuestionBase(Text, QuestionType.Text);
