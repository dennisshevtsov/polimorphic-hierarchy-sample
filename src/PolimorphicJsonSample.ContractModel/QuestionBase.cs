// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace PolimorphicJsonSample.ContractModel;

public abstract record class QuestionBase(string Text, QuestionType Type)
{
  protected static bool Equals(string[] a, string[] b)
  {
    if (a.Length != b.Length)
    {
      return false;
    }

    for (int i = 0; i < a.Length; i++)
    {
      if (a[i] != b[i])
      {
        return false;
      }
    }

    return true;
  }
}
