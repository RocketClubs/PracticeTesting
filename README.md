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

##The XML Format##

	<?xml version="1.0" encoding="utf-8"?>
	<QuestionPool xmlns="http://www.rocketclubs.com/study/practicetesting/" randomizedTestOrder="false">
	  <Name>The Example Test</Name>
	  <Version>2012</Version>
	  <Organization>Rocket Clubs</Organization>
	  <OrganizationWebsite>http://www.rocketclubs.com/</OrganizationWebsite>
	  <Link url="http://www.original.com/test/source" text="Question Pool Source" toolTip="Links are for posting relevant content such as where the original question pool source" />
	  <Link url="http://www.original.com/diagrams/source" text="Diagrams Source" toolTip="Make sure to give credit to the original source for your diagrams as well" />
	  <PassingScore>26</PassingScore>
	  <Section name="G1A" numberOnTest="1">
	    <Description>Many question pools are divided into sections and take a set number of questions from each section.</Description>
	    <Question number="01">
	      <Prompt>What is the question number?</Prompt>
	      <Answer choice="A" correct="false">It's a number starting from 1 and going to int.MaxValue</Answer>
	      <Answer choice="B" correct="false">It's actually useless</Answer>
	      <Answer choice="C" correct="true">It's a string that is combined with the section name to make a unique identifier for this question</Answer>
	      <Answer choice="D" correct="false">Some answer that is not true</Answer>
	    </Question>
	    <Question number="02">
	      <Prompt>How does the uri in a diagram work?</Prompt>
	      <Diagram title="My Diagram" uri="my-diagram.png" source="http://www.original.com/diagrams/source" />
	      <Answer choice="A" correct="false">It is a file in at the end of the source attribute</Answer>
	      <Answer choice="B" correct="true">It's and identifier to help the programmer decide where it is</Answer>
	      <Answer choice="C" correct="false">It's a path relative to the question pool itself</Answer>
	      <Answer choice="D" correct="false">It's a link back to the non-existent diagrams section of this spec</Answer>
	    </Question>
	  </Section>
	</QuestionPool>

##Common Problems##

- The XML namespace is `http://www.rocketclubs.com/study/practicetesting/`

