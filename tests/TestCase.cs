using BlackWidowOptimizationAlgorithm.OptimalizationAlgorithms.BlackWidow;
namespace tests
{
public class TestCase{
    public int populationSize {get;set;}
    public BlackWidowAlgorithmParameters blackWidowAlgorithmParameters { get; set; }
     public override string ToString()
   {
      return $"populationSize: {populationSize}, {blackWidowAlgorithmParameters}";
   }
}
}