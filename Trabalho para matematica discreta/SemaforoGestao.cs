using System;
using System.Threading;

namespace GestaoSemaforo
{
    public class Semaforo
    {
        public string Nome { get; set; }
        public bool EstaAberto { get; set; }
        public DateTime UltimaAlteracao { get; set; }
        
        public Semaforo(string nome)
        {
            Nome = nome;
            EstaAberto = true;
            UltimaAlteracao = DateTime.Now;
        }
    }
    
    public class SemaforoPedestre
    {
        public string Nome { get; set; }
        public bool EstaAberto { get; set; }
        public DateTime UltimaAlteracao { get; set; }
        public string DirecaoAssociada { get; set; }
        
        public SemaforoPedestre(string nome, string direcaoAssociada)
        {
            Nome = nome;
            DirecaoAssociada = direcaoAssociada;
            EstaAberto = false;
            UltimaAlteracao = DateTime.Now;
        }
    }
    
    public class GestorSemaforo
    {
        private Semaforo semaforoP;
        private Semaforo semaforoS;
        private SemaforoPedestre pedestreP;
        private SemaforoPedestre pedestreS;
        private readonly int tempoFechadoP = 60000; // 1 minuto em milissegundos
        private readonly int tempoFechadoS = 90000; // 1.5 minutos em milissegundos
        private readonly int tempoMinimoPedestre = 15000; // 15 segundos mínimo para pedestres
        
        public GestorSemaforo()
        {
            semaforoP = new Semaforo("P");
            semaforoS = new Semaforo("S");
            pedestreP = new SemaforoPedestre("Pedestre-P", "P");
            pedestreS = new SemaforoPedestre("Pedestre-S", "S");
            
            // Inicializa com P aberto e S fechado
            semaforoP.EstaAberto = true;
            semaforoS.EstaAberto = false;
            
            // Pedestres iniciam conforme semáforos de veículos
            AtualizarSemaforosPedestres();
        }
        
        public void IniciarGestao()
        {
            Console.WriteLine("=== SISTEMA DE GESTÃO DE SEMÁFOROS ===");
            Console.WriteLine("Semáforo P: Máximo 1 minuto fechado");
            Console.WriteLine("Semáforo S: Tempo variável");
            Console.WriteLine("Pedestres: Coordenados com semáforos de veículos");
            Console.WriteLine("Pressione Ctrl+C para parar\n");
            
            while (true)
            {
                VerificarEAlternarSemaforos();
                ExibirStatusSemaforos();
                Thread.Sleep(5000); // Verifica a cada 5 segundos
            }
        }
        
        private void AtualizarSemaforosPedestres()
        {
            DateTime agora = DateTime.Now;
            
            // Pedestre P pode atravessar quando semáforo P (veículos) está fechado
            bool novoStatusPedestreP = !semaforoP.EstaAberto;
            if (pedestreP.EstaAberto != novoStatusPedestreP)
            {
                pedestreP.EstaAberto = novoStatusPedestreP;
                pedestreP.UltimaAlteracao = agora;
            }
            
            // Pedestre S pode atravessar quando semáforo S (veículos) está fechado
            bool novoStatusPedestreS = !semaforoS.EstaAberto;
            if (pedestreS.EstaAberto != novoStatusPedestreS)
            {
                pedestreS.EstaAberto = novoStatusPedestreS;
                pedestreS.UltimaAlteracao = agora;
            }
        }
        
        private void VerificarEAlternarSemaforos()
        {
            DateTime agora = DateTime.Now;
            
            // Verifica se o semáforo P está fechado há mais de 1 minuto
            if (!semaforoP.EstaAberto)
            {
                double tempoFechado = (agora - semaforoP.UltimaAlteracao).TotalMilliseconds;
                if (tempoFechado >= tempoFechadoP)
                {
                    // P deve abrir (prioridade máxima)
                    semaforoP.EstaAberto = true;
                    semaforoP.UltimaAlteracao = agora;
                    
                    // S deve fechar
                    semaforoS.EstaAberto = false;
                    semaforoS.UltimaAlteracao = agora;
                    
                    Console.WriteLine("[ALTERAÇÃO] Semáforo P aberto por limite de tempo!");
                }
            }
            
            // Verifica se o semáforo S está fechado há mais tempo que o permitido
            if (!semaforoS.EstaAberto)
            {
                double tempoFechado = (agora - semaforoS.UltimaAlteracao).TotalMilliseconds;
                if (tempoFechado >= tempoFechadoS && semaforoP.EstaAberto)
                {
                    // Pode alternar para S se P não estiver no limite
                    double tempoAbertoP = (agora - semaforoP.UltimaAlteracao).TotalMilliseconds;
                    if (tempoAbertoP >= 30000) // P aberto por pelo menos 30 segundos
                    {
                        semaforoS.EstaAberto = true;
                        semaforoS.UltimaAlteracao = agora;
                        
                        semaforoP.EstaAberto = false;
                        semaforoP.UltimaAlteracao = agora;
                        
                        Console.WriteLine("[ALTERAÇÃO] Semáforo S aberto por rotação normal!");
                    }
                }
            }
            
            // Atualiza semáforos de pedestres
            AtualizarSemaforosPedestres();
        }
        
        private void ExibirStatusSemaforos()
        {
            DateTime agora = DateTime.Now;
            
            Console.Clear();
            Console.WriteLine("=== STATUS DOS SEMÁFOROS ===");
            Console.WriteLine($"Horário: {agora:HH:mm:ss}\n");
            
            // Status do Semáforo P (Veículos)
            string statusP = semaforoP.EstaAberto ? "🟢 ABERTO" : "🔴 FECHADO";
            double tempoP = (agora - semaforoP.UltimaAlteracao).TotalSeconds;
            string tempoStatusP = semaforoP.EstaAberto ? "aberto" : "fechado";
            
            Console.WriteLine($"🚗 Semáforo P (Veículos): {statusP}");
            Console.WriteLine($"   Tempo {tempoStatusP}: {tempoP:F0} segundos");
            
            if (!semaforoP.EstaAberto)
            {
                double tempoRestante = 60 - tempoP;
                if (tempoRestante > 0)
                {
                    Console.WriteLine($"   ⏰ Tempo restante para abertura obrigatória: {tempoRestante:F0}s");
                }
                else
                {
                    Console.WriteLine("   ⚠️ LIMITE EXCEDIDO! Deve abrir imediatamente!");
                }
            }
            
            // Status do Pedestre P
            string statusPedP = pedestreP.EstaAberto ? "🟢 PODE ATRAVESSAR" : "🔴 AGUARDE";
            Console.WriteLine($"🚶 Pedestre P: {statusPedP}");
            
            Console.WriteLine();
            
            // Status do Semáforo S (Veículos)
            string statusS = semaforoS.EstaAberto ? "🟢 ABERTO" : "🔴 FECHADO";
            double tempoS = (agora - semaforoS.UltimaAlteracao).TotalSeconds;
            string tempoStatusS = semaforoS.EstaAberto ? "aberto" : "fechado";
            
            Console.WriteLine($"🚗 Semáforo S (Veículos): {statusS}");
            Console.WriteLine($"   Tempo {tempoStatusS}: {tempoS:F0} segundos");
            
            // Status do Pedestre S
            string statusPedS = pedestreS.EstaAberto ? "🟢 PODE ATRAVESSAR" : "🔴 AGUARDE";
            Console.WriteLine($"🚶 Pedestre S: {statusPedS}");
            
            Console.WriteLine();
            
            // Passagem livre
            if (semaforoP.EstaAberto && !semaforoS.EstaAberto)
            {
                Console.WriteLine("🚗 PASSAGEM LIVRE: Direção P | 🚶 Pedestres podem atravessar na direção S");
            }
            else if (!semaforoP.EstaAberto && semaforoS.EstaAberto)
            {
                Console.WriteLine("🚗 PASSAGEM LIVRE: Direção S | 🚶 Pedestres podem atravessar na direção P");
            }
            else if (semaforoP.EstaAberto && semaforoS.EstaAberto)
            {
                Console.WriteLine("⚠️ ATENÇÃO: Ambos semáforos abertos (situação irregular)");
            }
            else
            {
                Console.WriteLine("🛑 TRÂNSITO PARADO: Ambos semáforos fechados | 🚶 Todos os pedestres podem atravessar");
            }
            
            Console.WriteLine("\n" + new string('=', 60));
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                GestorSemaforo gestor = new GestorSemaforo();
                gestor.IniciarGestao();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nSistema encerrado.");
            }
        }
    }
}