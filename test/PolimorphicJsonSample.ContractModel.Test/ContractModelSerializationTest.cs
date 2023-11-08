// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json;
using System.Text.RegularExpressions;

namespace PolimorphicJsonSample.ContractModel.Test;

[TestClass]
public sealed class ContractModelSerializationTest
{
  [TestMethod]
  public void Serialize_ArrayOfBases_ArrayOfDerivedObjectsSerialized()
  {
    // Arrange
    QuestionBase[] questions = ContractModelSerializationTest.CreateTestQuestions();

    // Act
    string actual = JsonSerializer.Serialize(questions, new JsonSerializerOptions
    {
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      TypeInfoResolver = new QuestionJsonTypeInfoResolver(),
    });

    // Assert
    string expected = Regex.Replace(ContractModelSerializationTest.CreateTestJson(), "\\s+", "");
    Assert.AreEqual(expected, actual);
  }

  private static string CreateTestJson() => @"
  [
    {
      ""type""  : 0,
      ""text""  : ""text_question:text"",
      ""answer"": ""text_question:answer""
    },
    {
      ""type""  : 1,
      ""text""  : ""yes_no_question:text"",
      ""answer"": 1
    },
    {
      ""type""   : 2,
      ""text""   : ""multiple_choice_question:text"",
      ""choices"": [
        ""multiple_choice_question:choice:0"",
        ""multiple_choice_question:choice:1"",
        ""multiple_choice_question:choice:2""
      ],
      ""answers"": [
        ""multiple_choice_question:choice:0"",
        ""multiple_choice_question:choice:2""
      ]
    },
    {
      ""type""   : 3,
      ""text""   : ""single_choice_question:text"",
      ""choices"": [
        ""single_choice_question:choice:0"",
        ""single_choice_question:choice:1"",
        ""single_choice_question:choice:2""
      ],
      ""answer"" : ""single_choice_question:choice:1""
    }
  ]";

  private static QuestionBase[] CreateTestQuestions() => new QuestionBase[]
  {
    new TextQuestion
    (
      Text  : "text_question:text",
      Answer: "text_question:answer"
    ),
    new YesNoQuestion
    (
      Text  : "yes_no_question:text",
      Answer: YesNo.Yes
    ),
    new MultipleChoiceQuestion
    (
      Text   : "multiple_choice_question:text",
      Choices: new[]
      {
        "multiple_choice_question:choice:0",
        "multiple_choice_question:choice:1",
        "multiple_choice_question:choice:2",
      },
      Answers : new[]
      {
        "multiple_choice_question:choice:0",
        "multiple_choice_question:choice:2",
      }
    ),
    new SingleChoiceQuestion
    (
      Text   : "single_choice_question:text",
      Choices: new[]
      {
        "single_choice_question:choice:0",
        "single_choice_question:choice:1",
        "single_choice_question:choice:2",
      },
      Answer : "single_choice_question:choice:1"
    ),
  };
}
