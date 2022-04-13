namespace YS.AWS.StateMachine.Abstractions.States;

// https://docs.aws.amazon.com/step-functions/latest/dg/amazon-states-language-choice-state.html
public class Choice : State
{
    public override StateType Type => StateType.Choice;

    public ChoiceRule[] Choices { get; set; }
    public string Default { get; set; }
}

public class ChoiceRule
{
    public string Variable { get; set; }

    public ChoiceRule[] And { get; set; }
    public ChoiceRule[] Or { get; set; }
    public ChoiceRule Not { get; set; }
    public bool? BooleanEquals { get; set; }
    public string BooleanEqualsPath { get; set; }
    public bool? IsBoolean { get; set; }
    public bool? IsNull { get; set; }
    public bool? IsNumeric { get; set; }
    public bool? IsPresent { get; set; }
    public bool? IsString { get; set; }
    public bool? IsTimestamp { get; set; }
    public decimal? NumericEquals { get; set; }
    public string NumericEqualsPath { get; set; }
    public decimal? NumericGreaterThan { get; set; }
    public string NumericGreaterThanPath { get; set; }
    public decimal? NumericGreaterThanEquals { get; set; }
    public string NumericGreaterThanEqualsPath { get; set; }
    public decimal? NumericLessThan { get; set; }
    public string NumericLessThanPath { get; set; }
    public decimal? NumericLessThanEquals { get; set; }
    public string NumericLessThanEqualsPath { get; set; }
    public string StringEquals { get; set; }
    public string StringEqualsPath { get; set; }
    public string StringGreaterThan { get; set; }
    public string StringGreaterThanPath { get; set; }
    public string StringGreaterThanEquals { get; set; }
    public string StringGreaterThanEqualsPath { get; set; }
    public string StringLessThan { get; set; }
    public string StringLessThanPath { get; set; }
    public string StringLessThanEquals { get; set; }
    public string StringLessThanEqualsPath { get; set; }
    public string StringMatches { get; set; }
    public DateTime? TimestampEquals { get; set; }
    public string TimestampEqualsPath { get; set; }
    public DateTime? TimestampGreaterThan { get; set; }
    public string TimestampGreaterThanPath { get; set; }
    public DateTime? TimestampGreaterThanEquals { get; set; }
    public string TimestampGreaterThanEqualsPath { get; set; }
    public DateTime? TimestampLessThan { get; set; }
    public string TimestampLessThanPath { get; set; }
    public DateTime? TimestampLessThanEquals { get; set; }
    public string TimestampLessThanEqualsPath { get; set; }

    public string Next { get; set; }
}