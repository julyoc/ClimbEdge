using System.ComponentModel;

namespace ClimbEdge.Domain.Enums.AI
{
    /// <summary>
    /// Tipos de modelos de inteligencia artificial
    /// </summary>
    public enum AIModelType
    {
        /// <summary>
        /// Red neuronal tradicional
        /// </summary>
        NeuralNetwork,

        /// <summary>
        /// Aprendizaje profundo
        /// </summary>
        DeepLearning,

        /// <summary>
        /// Algoritmo genético
        /// </summary>
        GeneticAlgorithm,

        /// <summary>
        /// Modelo de lenguaje (GPT, etc)
        /// </summary>
        LanguageModel,

        /// <summary>
        /// Aprendizaje por refuerzo
        /// </summary>
        ReinforcementLearning,

        /// <summary>
        /// Árbol de decisión
        /// </summary>
        DecisionTree,

        /// <summary>
        /// Bosque aleatorio
        /// </summary>
        RandomForest,

        /// <summary>
        /// Máquina de vectores de soporte
        /// </summary>
        SVM,

        /// <summary>
        /// Conjunto de modelos
        /// </summary>
        Ensemble
    }
}
