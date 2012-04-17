#PracticeTesting#

Generate practice tests (go figure) from question pools to help you study for your exams!

##Quick Usage##

The easiest way to use the PracticeTesting library is to just load up an existing XML question pool and create a test from it.  Then you ask each question and record the answer.  In a console app, the main test function would be similar to this:

    var questionPoolFileName = @"c:\the\full\path\to\your\question\pool.xml";
    var questionPool = QuestionPool.LoadFromXmlFile(questionPoolFileName);
    var practiceTest = questionPool.CreatePracticeTest();
    
    foreach(var practiceTestQuestion in practiceTest.Questions)
    {
    	// ask the question and get the answer, `AskAndGetAnswer()` is your function
    	var answer = AskAndGetAnswer(practiceTestQuestion);
    	
    	// record my answer
    	practiceTestQuestion.AnswerChosen = answer;
    }
    
If you are using this in a web application, the practice test is likely destroyed before the answers are provided.  For this reason, `QuestionPool.CreatePracticeTest()` has an overload which takes an enumerable of question ids, which are generated from the `PracticeTestQuestion.QuestionId` property.

    [HttpPost]
    public ActionResult GradeTest(string[] answers, string[] questionIds)
    {
        // get the test and apply the answers
        var questionPool = GetQuestionPool();
        var practiceTest = pool.CreatePracticeTest(questionIds);

        for (int qIndex = 0, numberOfQuestions = answers.Count; qIndex < numberOfQuestions; qIndex += 1)
        {
            var answerId = answers[qIndex];
            if (answerId == string.Empty) continue; // they skipped this question
            
            var question = test.Questions.ElementAt(questionIndex);
            question.AnswerChosen = question.Choices.Single(a => a.OptionId == answerId);
        }

        return View("GradedTest", practiceTest);
    }

##Common Problems##

- The XML namespace is `http://www.rocketclubs.com/study/practicetesting/`

