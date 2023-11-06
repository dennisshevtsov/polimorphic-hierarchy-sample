﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace PolimorphicJsonSample;

public sealed record class SingleChoiceQuestion(
  string Text,
  [property: JsonPropertyOrder(2)] string[] Choices,
  [property: JsonPropertyOrder(3)] string? Answer)
  : QuestionBase(Text, QuestionType.SingleChoice)
{
#pragma warning disable CS8851 // Record defines 'Equals' but not 'GetHashCode'.
  public bool Equals(SingleChoiceQuestion? other)
#pragma warning restore CS8851 // Record defines 'Equals' but not 'GetHashCode'.
  {
    if (other is null)
    {
      return false;
    }

    if (object.ReferenceEquals(this, other))
    {
      return true;
    }

    if (Text != other.Text)
    {
      return false;
    }

    if (!QuestionBase.Equals(Choices, other.Choices))
    {
      return false;
    }

    if (Answer != other.Answer)
    {
      return false;
    }

    return true;
  }
}
