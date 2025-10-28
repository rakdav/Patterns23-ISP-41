IExpression terminalExpression = new Terminalexpression("hello");
IExpression nonterminalExpression=new NonTerminalExpression(terminalExpression,2);
nonterminalExpression.Interpret();

interface IExpression
{
    public void Interpret();
}
class Terminalexpression : IExpression
{
    private string _statement;

    public Terminalexpression(string statement)=> _statement = statement;
    public void Interpret()
    {
        Console.WriteLine(this._statement+" TerminalExpression");
    }
}
class NonTerminalExpression : IExpression
{
    private IExpression _expression;
    private int _times;
    public NonTerminalExpression(IExpression expression, int times)
    {
        _expression = expression;
        _times = times;
    }
    public void Interpret()
    {
        for (int i = 0; i < _times; i++)
        {
            this._expression.Interpret();
        }
    }
}