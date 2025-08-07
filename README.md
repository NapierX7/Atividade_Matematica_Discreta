🚦 Sistema Completo de Gestão de Semáforos
📋 Descrição do Projeto

Este projeto implementa um sistema completo de gestão de semáforos que inclui:

    Backend em C#: Lógica de controle de semáforos para veículos e pedestres
    Frontend HTML/JavaScript: Visualização 3D interativa em tempo real
    Integração Web: Interface completa para demonstração e controle

O sistema simula o controle de tráfego em uma interseção com duas direções (P e S) para veículos, além de semáforos coordenados para pedestres, seguindo regras específicas de temporização e segurança.
🎯 Requisitos Atendidos
Backend C#:

✅ Linguagem: C#
✅ Gestão de Semáforo P: Máximo 1 minuto fechado
✅ Loop contínuo: Sistema roda indefinidamente
✅ Status em tempo real: Mostra qual semáforo está aberto/fechado
✅ Indicação de passagem livre: Informa qual direção tem trânsito liberado
✅ Semáforos de pedestres: Coordenação automática com semáforos de veículos
Frontend Web:

✅ Visualização 3D: Interface moderna com Three.js
✅ Tempo real: Atualização automática dos estados
✅ Interface responsiva: Compatível com diferentes dispositivos
✅ Controles interativos: Botões para controle manual
✅ Alertas visuais e sonoros: Feedback completo para o usuário
🔧 Funcionalidades
Sistema de Veículos:

    Semáforo P: Não pode ficar fechado por mais de 1 minuto
    Semáforo S: Tempo variável, mas respeita a prioridade do P
    Alternância inteligente: Sistema alterna automaticamente respeitando as regras
    Monitoramento contínuo: Atualização a cada 5 segundos

Sistema de Pedestres:

    Coordenação automática: Semáforos de pedestres coordenados com veículos
    Segurança prioritária: Pedestres só atravessam quando veículos estão parados
    Tempo de travessia: 15 segundos para travessia segura
    Alertas sonoros: Sinais sonoros para acessibilidade

Interface Web:

    Visualização 3D: Representação realista da interseção
    Controles manuais: Botões para emergência e testes
    Informações em tempo real: Status, tempos e alertas
    Design responsivo: Funciona em desktop e mobile

Informações Exibidas:

    ✅ Status de todos os semáforos (veículos e pedestres)
    ⏰ Tempos decorridos e restantes
    ⚠️ Alertas de limite e emergência
    🚗 Indicação de passagem livre para veículos
    🚶 Status de travessia para pedestres
    🛑 Situações irregulares e emergências

🚀 Como Executar
🌐 Sistema Web Completo (Recomendado)
Pré-requisitos:

    Navegador web moderno (Chrome, Firefox, Safari, Edge)
    Conexão com internet (para bibliotecas CDN)

Execução:

    Abrir o arquivo semaforo_visual.html em qualquer navegador
    O sistema iniciará automaticamente
    Use os controles na interface para interagir

💻 Sistema C# (Backend)
Pré-requisitos:

    .NET Framework ou .NET Core instalado
    Visual Studio, VS Code ou qualquer editor C#

Opção 1: Compilar e Executar via Terminal

# Navegar até o diretório do arquivo
cd "c:\Users\napie\iCloudDrive\Faculdade\Setor de programas"

# Compilar o programa
csc SemaforoGestao.cs

# Executar
SemaforoGestao.exe

Opção 2: Visual Studio

    Abrir o Visual Studio
    Criar um novo projeto Console Application
    Substituir o código pelo conteúdo do arquivo SemaforoGestao.cs
    Executar (F5)

Opção 3: VS Code

    Abrir o arquivo SemaforoGestao.cs no VS Code
    Instalar a extensão C# se necessário
    Usar o terminal integrado para compilar e executar

📊 Exemplo de Saída

=== STATUS DOS SEMÁFOROS ===
Horário: 14:30:25

Semáforo P: 🟢 ABERTO
Tempo aberto: 45 segundos

Semáforo S: 🔴 FECHADO
Tempo fechado: 45 segundos

🚗 PASSAGEM LIVRE: Direção P

==================================================

🛠️ Tecnologias Utilizadas
Backend (C#):

    Linguagem: C# (.NET Framework/Core)
    Paradigma: Programação Orientada a Objetos
    Threading: System.Threading para controle de tempo
    Console: Interface de linha de comando

Frontend (Web):

    HTML5: Estrutura da página
    CSS3: Estilização e animações
    JavaScript ES6+: Lógica de interface e interação
    Three.js: Biblioteca para gráficos 3D
    Web APIs: Audio API para alertas sonoros

Recursos Visuais:

    Ícones: Font Awesome para elementos visuais
    Animações: CSS Transitions e Keyframes
    Layout: Flexbox e Grid para responsividade
    Cores: Esquema de cores semafóricas padrão

🏗️ Estrutura do Código
Backend C# - Classes Principais:

    Semaforo: Representa um semáforo individual
        Propriedades: Nome, Status (Aberto/Fechado), Última Alteração

    SemaforoPedestre: Especialização para semáforos de pedestres
        Coordenação automática com semáforos de veículos
        Lógica de segurança para travessia

    GestorSemaforo: Controla a lógica de alternância
        Métodos principais:
            IniciarGestao(): Loop principal
            VerificarEAlternarSemaforos(): Lógica de controle
            ExibirStatusSemaforos(): Interface visual

    Program: Ponto de entrada da aplicação

Frontend Web - Estrutura:

    HTML: Estrutura semântica da interface
    CSS: Estilos, animações e responsividade
    JavaScript: Lógica de simulação e interação
    Three.js: Renderização 3D dos semáforos

⚙️ Lógica de Controle
Prioridades:

    Máxima: Semáforo P não pode ficar fechado > 1 minuto
    Normal: Alternância equilibrada quando possível
    Segurança: Evitar situações onde ambos estão abertos/fechados

Tempos Configurados:

    Semáforo P fechado: Máximo 60 segundos
    Semáforo S fechado: Máximo 90 segundos
    Tempo mínimo aberto: 30 segundos
    Intervalo de verificação: 5 segundos

🎨 Recursos Visuais

    🟢 Semáforo aberto (verde)
    🔴 Semáforo fechado (vermelho)
    ⏰ Contador de tempo
    ⚠️ Alertas de limite
    🚗 Indicação de passagem livre
    🛑 Situações de parada

🔄 Controle de Execução

    Iniciar: Execute o programa
    Parar: Pressione Ctrl+C
    Monitorar: A tela atualiza automaticamente

📁 Arquivos do Projeto
Arquivos Principais:

    SemaforoGestao.cs: Código fonte C# completo
    semaforo_visual.html: Interface web com visualização 3D
    README_Semaforo.md: Documentação completa

Funcionalidades por Arquivo:
SemaforoGestao.cs:

    Lógica de controle de semáforos
    Classes para veículos e pedestres
    Sistema de temporização
    Interface de console

semaforo_visual.html:

    Visualização 3D interativa
    Controles de usuário
    Simulação em tempo real
    Interface responsiva

📝 Observações
Sistema C#:

    Thread-safe e pode rodar indefinidamente
    Interface de console limpa e atualizada
    Todas as regras de negócio respeitadas
    Código modular e extensível

Sistema Web:

    Compatível com todos os navegadores modernos
    Não requer instalação ou configuração
    Interface intuitiva e acessível
    Visualização realista em 3D

Integração:

    Ambos os sistemas seguem a mesma lógica de negócio
    Podem ser executados independentemente
    Demonstram diferentes abordagens de interface

🎓 Contexto Acadêmico

Este projeto foi desenvolvido para atender aos requisitos de uma disciplina que envolve:
Competências Técnicas:

    Programação em C#: POO, threads, controle de fluxo
    Desenvolvimento Web: HTML5, CSS3, JavaScript ES6+
    Gráficos 3D: Three.js para visualização
    Interface de usuário: Console e web
    Lógica de negócio: Regras de tráfego e segurança

Conceitos Aplicados:

    Orientação a Objetos: Classes, herança, encapsulamento
    Programação Assíncrona: Timers e eventos
    Design Patterns: Observer, State Machine
    Responsividade: Design adaptável a diferentes telas
    Acessibilidade: Alertas sonoros e visuais

Metodologia:

    Análise de Requisitos: Especificação detalhada
    Design de Sistema: Arquitetura modular
    Implementação: Desenvolvimento iterativo
    Testes: Validação de regras de negócio
    Documentação: README completo e comentários

🌐 Integração Web - Backend C# no Navegador
Como Usar a Integração:

    Abrir o Sistema Web:
        Abra o arquivo semaforo_visual.html no navegador
        O sistema visual iniciará automaticamente

    Executar o Backend C#:
        Role para baixo até a seção "Simulação do Backend C#"
        Clique no botão "🚀 Iniciar Backend C#"
        Observe o console simulando a saída do programa C#

    Comparar os Sistemas:
        Parte Superior: Visualização 3D interativa
        Parte Inferior: Console do backend C# em tempo real
        Ambos seguem a mesma lógica de negócio

Funcionalidades da Integração:

    Console Realista: Simula exatamente a saída do programa C#
    Mesma Lógica: Replica as classes e métodos do backend
    Tempo Real: Atualização sincronizada a cada 5 segundos
    Controles: Botões para iniciar/parar o backend
    Scroll Automático: Console sempre mostra as informações mais recentes

Vantagens da Demonstração Web:

    Facilidade de Apresentação: Não requer compilação ou instalação
    Visualização Dupla: Interface gráfica + console textual
    Interatividade: Controles para demonstrar funcionalidades
    Portabilidade: Funciona em qualquer dispositivo com navegador
    Comparação Direta: Mostra ambas as abordagens simultaneamente

📊 Resumo para Apresentação
O que foi Desenvolvido:

1. Backend C# Completo:

    ✅ Sistema de gestão de semáforos para veículos
    ✅ Integração de semáforos para pedestres
    ✅ Lógica de prioridade e temporização
    ✅ Interface de console com informações detalhadas
    ✅ Classes modulares e extensíveis

2. Frontend Web Interativo:

    ✅ Visualização 3D com Three.js
    ✅ Interface responsiva e moderna
    ✅ Controles interativos para demonstração
    ✅ Alertas visuais e sonoros
    ✅ Simulação em tempo real

3. Integração Completa:

    ✅ Backend C# simulado no navegador
    ✅ Console web replicando saída do programa
    ✅ Demonstração lado a lado dos dois sistemas
    ✅ Mesma lógica de negócio em ambas as implementações

Tecnologias Demonstradas:

    C#: POO, Threading, Console Applications
    HTML5/CSS3: Estrutura e estilização moderna
    JavaScript ES6+: Lógica de interface e simulação
    Three.js: Gráficos 3D para visualização
    Design Responsivo: Compatibilidade multi-dispositivo

Diferenciais do Projeto:

    Dupla Implementação: Backend robusto + Frontend interativo
    Integração Inovadora: C# executando no navegador via JavaScript
    Documentação Completa: README detalhado com instruções
    Facilidade de Demonstração: Um clique para executar
    Escalabilidade: Código modular e extensível

Desenvolvido por: Victor Hugo Valim Napier
Curso: Engenharia de Software - UCB
Data: Agosto 2025
Tecnologias: C#, HTML5, CSS3, JavaScript, Three.js
