# Jogo_Space_Invaders_2D

[![Vídeo de Introdução](https://github.com/GabrielVilelaPHS/Jogo_Space_Invaders_2D/blob/main/foto%20jogo%20space%20invaders.jpg)](https://youtu.be/hFGvBuxvd1U)

Recriando o jogo Space Invaders lançado originalmente em 1978. O jogo atualmente consiste em uma cena com diversos inimigos valendo pontos, barreiras e a própria nave do jogador. Para a criação deste jogo foi utilizado a engine Unity.

## Jogabilidade
- (tecla A | setinha esquerda): mover nave para a esquerda;
- (tecla D | setinha direita): mover nave para a direita;
- (tecla W | setinha para cima):  mover nave para cima;
- (tecla S | setinha para baixo):  mover nave para baixo;
- (tecla espaço | click do mouse): atira balas;

## Caracteríticas
Entre os tiros, foi colocado um tempo em milisegundos de espera, limitando a quantidade de balas por tempo. O tiro só afeta um alien por vez e também é destruido caso colida com a bala do inimigo ou barreira aliada. A barreira por sua vez, tem uma durabilidade total, ela desapare ao levar 4 tiros do inimigo ou ao colidir com um alien. Os tiros do inimigo são gerados de forma aleatória a cada segundo através do sorteio de qual alien irá atirar no momento.

Os inimigos são gerados de forma pocedural em um bloco linhado através de um gameobjet. Para cada inimigo morto a velocidade de deslocamento do inimigo é aumentada em 0.1s e o contador "score" é aumentado. Caso o alien branco seja morto, é acrecestado no score 10 pontos, se for a nave vermelha, o valor adiconado é 100. Após o jogador ser morto, o score atual é comparado ao recorde existente, caso o score seja maior que o recorde, recorde terá seu valor substituído. 

A cena é reiniciada caso: 
- A nave leve um tiro;
- A nave colida com um alien;
- Um alien chegue totalmente ao limite inferior da tela;
