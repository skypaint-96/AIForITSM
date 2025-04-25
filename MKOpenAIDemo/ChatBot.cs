using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.Ollama;
using Microsoft.SemanticKernel.Agents;
using Microsoft.SemanticKernel.Agents.Chat;
using OllamaSharp;
using Azure;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using System.Configuration;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace MKOpenAIDemo
{
    class ChatBot
    {
        const string ASSEMBLYLOCATION_MISSING = "ASSEMBLYLOCATION_MISSING";
        const string CONFIGFILE_MISSING = "CONFIGFILE_MISSING";
        const string CONFIGPROPERTY_MISSING = "CONFIGPROPERTY_MISSING";

        public ChatBot()
        {
            //ChatCompletionAgent uiAgent = NewUIAgent();
            ChatMessages = new ChatHistoryAgentThread();
            ChatMessages.CreateAsync().Wait();
            OllamaAgent = NewOllamaChatAgent();
            AzureOpenAIAgent = NewAzureOpenAIChatAgent();
            //AgentGroupChat agentGroupChat = new AgentGroupChat([uiAgent, taskAgent]);
            //while (true)
            //{
            //    GetNewCommandFromUser(chatMessages);
            //    await GenerateAIResponses(chatMessages, taskAgent);
            //}

        }

        static IConfigurationRoot Config
        {
            get
            {
                Assembly asmRaw = Assembly.GetAssembly(typeof(Program)) ?? throw new ConfigurationErrorsException(ASSEMBLYLOCATION_MISSING);
                string rootPath = Path.GetDirectoryName(asmRaw.Location) ?? throw new ConfigurationErrorsException(CONFIGFILE_MISSING);
                return new ConfigurationBuilder().SetBasePath(rootPath).AddJsonFile("AppConfig.json").Build();
            }
        }

        public ChatHistoryAgentThread ChatMessages { get; private set; }
        public ChatCompletionAgent OllamaAgent { get; private set; }
        public ChatCompletionAgent AzureOpenAIAgent { get; private set; }
        public string? UserInput { get; set; }
        public string? AIResponse { get; private set; }


        public async Task SendMessage()
        {
            if (!string.IsNullOrWhiteSpace(UserInput))
            {
                // Add the user's message to the chat history
                ChatMessages.ChatHistory.AddUserMessage(UserInput);
                //AgentThread chatThread = new AgentThread();
                // Get the chatbot's response
                AIResponse = "";
                await foreach (ChatMessageContent response in OllamaAgent.InvokeAsync(ChatMessages))
                {
                    AIResponse += response.Content;
                    //Console.Write(response.Content);
                }

                //var response = await ChatBotService.GetChatAsync(UserInput);

                // Add the chatbot's response to the chat history
                //ChatMessages.Add(new ChatMessage { Role = "Bot", Content = response });

                // Clear the input field
                UserInput = string.Empty;
            }
        }
        private static ChatCompletionAgent NewOllamaChatAgent()
        {
            string modelId = Config["ModelSettings:OllamaModelID"] ?? throw new ConfigurationErrorsException(CONFIGPROPERTY_MISSING);
            string endpoint = Config["ModelSettings:OllamaEndpoint"] ?? throw new ConfigurationErrorsException(CONFIGPROPERTY_MISSING);
            string prompt = Config["ModelSettings:OllamaPrompt"] ?? throw new ConfigurationErrorsException(CONFIGPROPERTY_MISSING);
#pragma warning disable SKEXP0070 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            Kernel uiKernel = Kernel.CreateBuilder().AddOllamaChatCompletion(modelId, new Uri(endpoint)).Build();
#pragma warning restore SKEXP0070 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            ChatCompletionAgent uiAgent = new ChatCompletionAgent()
            {
                Kernel = uiKernel,
                Name = "User Interaction Agent",
                Description = "Agent to take queries/requests from the user, understand them, identify an expected outcome and provide an answer. if a query or request requires research or an action to be performed, instructions are to be provided to the task manager agent.",
                Instructions = prompt
            };
            return uiAgent;
        }
        private static ChatCompletionAgent NewAzureOpenAIChatAgent()
        {
            string modelId = Config["ModelSettings:AzureOpenAIModelID"] ?? throw new ConfigurationErrorsException(CONFIGPROPERTY_MISSING);
            string endpoint = Config["ModelSettings:AzureOpenAIEndpoint"] ?? throw new ConfigurationErrorsException(CONFIGPROPERTY_MISSING);
            string deploymentName = Config["ModelSettings:AzureOpenAIDeploymentName"] ?? throw new ConfigurationErrorsException(CONFIGPROPERTY_MISSING);
            string apiKey = Config["ModelSettings:AzureOpenAIApiKey"] ?? throw new ConfigurationErrorsException(CONFIGPROPERTY_MISSING);
            string prompt = Config["ModelSettings:AzureOpenAIPrompt"] ?? throw new ConfigurationErrorsException(CONFIGPROPERTY_MISSING);
#pragma warning disable SKEXP0070 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            Kernel kernel = Kernel.CreateBuilder().AddAzureOpenAIChatCompletion(deploymentName: deploymentName, endpoint: endpoint, apiKey: apiKey, modelId: modelId).Build();
#pragma warning restore SKEXP0070 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            ChatCompletionAgent uiAgent = new ChatCompletionAgent()
            {
                Kernel = kernel,
                Name = "User Interaction Agent",
                Description = "Agent to take queries/requests from the user, understand them, identify an expected outcome and provide an answer. if a query or request requires research or an action to be performed, instructions are to be provided to the task manager agent.",
                Instructions = prompt
            };
            return uiAgent;
        }
    }
}