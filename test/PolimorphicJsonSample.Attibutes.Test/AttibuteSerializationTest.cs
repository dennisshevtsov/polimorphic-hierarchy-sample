// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json;
using System.Text.RegularExpressions;

namespace PolimorphicJsonSample.Attibutes.Test;

[TestClass]
public sealed class AttibuteSerializationTest
{
  [TestMethod]
  public void Serialize_ArrayOfBases_ArrayOfDerivedObjectsSerialized()
  {
    // Arrange
    QuestionBase[] questions = AttibuteSerializationTest.CreateTestQuestions();

    // Act
    string actual = JsonSerializer.Serialize(questions, new JsonSerializerOptions
    {
       PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    });

    // Assert
    string expected = Regex.Replace(AttibuteSerializationTest.CreateTestJson(), "\\s+", "");
    Assert.AreEqual(expected, actual);
  }

  [TestMethod]
  public void Deserialize_Json_ArrayOfDerivedObjectsDeserialized()
  {
    // Arrange
    string json = AttibuteSerializationTest.CreateTestJson();

    // Act
    QuestionBase[]? actual = JsonSerializer.Deserialize<QuestionBase[]>(json, new JsonSerializerOptions
    {
       PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    });

    // Assert
    QuestionBase[] expected = AttibuteSerializationTest.CreateTestQuestions();

    Assert.IsNotNull(actual);
    Assert.AreEqual(expected.Length, actual.Length);

    for (int i = 0; i < expected.Length; i++)
    {
      Assert.AreEqual(expected[i], actual[i]);
    }
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
