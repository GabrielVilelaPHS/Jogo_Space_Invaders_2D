# Jogo_Space_Invaders_2D
# 
Recriando o jogo Space Invaders lançado originalmente em 1978. O jogo atualmente consiste em uma cena com diversos inimigos valendo pontos, barreiras e a própria nave do jogador. Para a criação deste jogo foi utilizado a engine Unity.

## Jogabilidade
- (tecla A | setinha esquerda): mover nave para a esquerda;
- (tecla D | setinha direita): mover nave para a direita;
- (tecla W | setinha para cima):  mover nave para cima;
- (tecla S | setinha para baixo):  mover nave para baixo;
- (tecla espaço | click do mouse): atira balas;

## Caracteríticas
Entre os tiros, foi colocado um tempo em milisegundos de espera, limitando a quantidade de balas por tempo. O tiro só afeta um alien por vez e também é destruido caso colida com a bala do inimigo ou barreira aliada. A barreira por sua vez, tem uma durabilidade total, ela desapare ao levar 4 tiros do inimigo ou ao colidir com um alien. Os tiros do inimigo são gerados de forma aleatória a cada segundo através do sorteio de qual alien irá atirar no momento.

A cena é reiniciada caso: 
- A nave leve um tiro;
- A nave colida com um alien;
- Um alien chegue totalmente ao limite inferior da tela;
