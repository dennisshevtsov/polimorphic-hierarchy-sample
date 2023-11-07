// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace PolimorphicJsonSample.ContractModel;

public sealed record class TextQuestion(string Text, string? Answer)
  : QuestionBase(Text, QuestionType.Text);
