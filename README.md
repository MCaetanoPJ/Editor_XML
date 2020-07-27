# Editor_XML
Monitoramento de Arquivos XML em pasta especifica

Funcionamento do sistema:
Uma pasta especifica é seleciona para ser monitorada, essa pasta será monitorada em específico somente por arquivos com extensão .XML que forem criados, ignorando arquivos editados ou renomeados por meio da biblioteca System.IO e seu método "FileSystemWatcher"

Dentro do programa foram criados 06 métodos listados abaixo:
# MonitorarArquivos
Responsável por controlar como o método "FileSystemWatcher" deve se comportar e impondo a condição onde deve ser ativado somente quando o arquivo com o endereço da pasta fornecido pelo usuário existir
# OnFileChanged
Obedecendo as informações do método "MonitorarArquivos" é responsável por monitorar a pasta informada pelo usuário e enviar o endereço juntamente com o nome do arquivo para  método "Altera_Arquivo_XML"
# Salvar_Diretorio_Arquivo_TXT
Possui como objetivo criar um arquivo de texto contendo o endereço da pasta que o usuário informou
# Ler_Diretorio_Arquivos_TXT
Possui como objetivo Ler o conteúdo do arquivo criado pelo método "Salvar_Diretorio_Arquivo_TXT" e atribuir o endereço lido, a uma váriavel pública no escopo do programa, para todos os método poderem utilizar essa informação
# Ler_Arquivos_XML_no_Diretorio_Selecionado
Tem como objetivo Ler todos os arquivos com .extensão (.XML) dentro da pasta informada pelo usuário e colocar o endereço desses arquivos juntamente com o seu nome, em um vetor e enviar para o método "Altera_Arquivo_XML"
# Altera_Arquivo_XML
Possui a principal funcionalidade do sistema, pois a leitura e escrita o arquivo (.XML), esse método recebe como parametro o endereço do arquivo que deve ser alterado e após a alteração estar finalizada o método atualiza o arquivo e finaliza
