using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Brain
    {
        #region ///////////////////////// Properties //////////////////////////////////
        /// <summary>
        /// A List of all neurons in the brain
        /// </summary>
        List<Neuron>    Neurons;

        /// <summary>
        /// A List of all Synapses in the brain
        /// </summary>
        List<Synapse>   Synapses;

        /// <summary>
        /// A List of all Sense Inputs into the brain
        /// </summary>
        List<Sense>     Senses;

        /// <summary>
        /// A List of all Control Outputs from the brain
        /// </summary>
        List<int>       Controls;

        /// <summary>
        ///  A postive value specifies the number of Neurons. 
        ///  A negative value means it will be randomized during training
        /// </summary>
        int NeuronCount;
        /// <summary>
        ///  a postive value specifies the number of Synapses. 
        ///  A negative values means it will be randomized during training
        /// </summary>
        int SynapseCount;
        /// <summary>
        ///  a postive value specifies the number of Senses. 
        ///  A negative values means it will be randomized during training
        /// </summary>
        int SenseCount;
        #endregion

        public Brain()
        {
            Random rand = new Random();

            int neuron = rand.Next(1, 100);
            int synapse = rand.Next(1, 100);
            int sense = rand.Next(1, 100);

            Init(neuron, synapse, sense);


            NeuronCount = -1;
            SynapseCount = -1;
            SenseCount = -1;
        }

        public Brain(int numNeurons , int numSynapses , int numSenses)
        {
            NeuronCount = numNeurons;
            SynapseCount = numSynapses;
            SenseCount = numSenses;

            Init(numNeurons, numSynapses, numSenses);
        }

        private void Init(int n, int sy, int se)
        {
            int i = 0;

            Neurons = new List<Neuron>();
            Synapses = new List<Synapse>();
            Senses = new List<Sense>();

            for (i = 0; i < n; i++)
            {
                Neurons.Add(new Neuron());
            }

            for (i = 0; i < sy; i++)
            {
                Synapses.Add(new Synapse());
            }

            for (i = 0; i < se; i++)
            {
                Senses.Add(new Sense());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Inputs"></param>
        /// <param name="ExpectedOutput"></param>
        public void Train(List<Sense> Inputs, List<MotorNeuron> ExpectedOutput)
        {

        }
    }
}
