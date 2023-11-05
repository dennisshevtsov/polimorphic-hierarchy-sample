// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace PolimorphicJsonSample;

public sealed record class MultipleChoiceQuestion(string Text, string[] Choices, string[] Answers)
  : QuestionBase(Text, QuestionType.Text);
