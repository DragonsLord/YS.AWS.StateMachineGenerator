using YS.AWS.StateMachine.Abstractions.Values;

namespace YS.AWS.StateMachine.Abstractions.States;

// https://docs.aws.amazon.com/step-functions/latest/dg/amazon-states-language-choice-state.html
public class Choice : State
{
    public override StateType Type => StateType.Choice;

    public ChoiceRule[] Choices { get; set; }
    public string Default { get; set; }

    protected override IEnumerable<(string Key, object Value, bool Pathable)> GetSerializedFields()
    {
        yield return (nameof(Choices), Choices, false);
        yield return (nameof(Default), Default, false);
    }
}

public class ChoiceRule
{
    public string Variable { get; set; }

    public ChoiceRule[] And { get; set; }
    public ChoiceRule[] Or { get; set; }
    public ChoiceRule Not { get; set; }
    public bool? BooleanEquals { get; set; }
    public JsonPath BooleanEqualsPath { get; set; }
    public bool? IsBoolean { get; set; }
    public bool? IsNull { get; set; }
    public bool? IsNumeric { get; set; }
    public bool? IsPresent { get; set; }
    public bool? IsString { get; set; }
    public bool? IsTimestamp { get; set; }
    public decimal? NumericEquals { get; set; }
    public JsonPath NumericEqualsPath { get; set; }
    public decimal? NumericGreaterThan { get; set; }
    public JsonPath NumericGreaterThanPath { get; set; }
    public decimal? NumericGreaterThanEquals { get; set; }
    public JsonPath NumericGreaterThanEqualsPath { get; set; }
    public decimal? NumericLessThan { get; set; }
    public JsonPath NumericLessThanPath { get; set; }
    public decimal? NumericLessThanEquals { get; set; }
    public JsonPath NumericLessThanEqualsPath { get; set; }
    public string StringEquals { get; set; }
    public JsonPath StringEqualsPath { get; set; }
    public string StringGreaterThan { get; set; }
    public JsonPath StringGreaterThanPath { get; set; }
    public string StringGreaterThanEquals { get; set; }
    public JsonPath StringGreaterThanEqualsPath { get; set; }
    public string StringLessThan { get; set; }
    public JsonPath StringLessThanPath { get; set; }
    public string StringLessThanEquals { get; set; }
    public JsonPath StringLessThanEqualsPath { get; set; }
    public string StringMatches { get; set; }
    public DateTime? TimestampEquals { get; set; }
    public JsonPath TimestampEqualsPath { get; set; }
    public DateTime? TimestampGreaterThan { get; set; }
    public JsonPath TimestampGreaterThanPath { get; set; }
    public DateTime? TimestampGreaterThanEquals { get; set; }
    public JsonPath TimestampGreaterThanEqualsPath { get; set; }
    public DateTime? TimestampLessThan { get; set; }
    public JsonPath TimestampLessThanPath { get; set; }
    public DateTime? TimestampLessThanEquals { get; set; }
    public JsonPath TimestampLessThanEqualsPath { get; set; }

    public string Next { get; set; }
}