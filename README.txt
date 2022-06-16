Groupe :
- Azéline Aillet
- Adam Ismaili
- Souleymane Sentici
- Yvon Morice

Contrôles :
WASD (Qwerty) / ZQSD (Azerty) / flèches : déplacements
Espace: saut
Clic gauche / Ctrl: tirer
R / Clic droit: recharger
echap: menu de pause

Notre jeu est un fps dans un monde de fantaisie.
Le but est de battre les ennemis et leur spawners en leur tirant dessus.
Le rythme d'apparition des ennemis augmente au fur et à mesure que les spawners sont détruits,
il est donc recommandé de détruire ceux-ci en priorité pour éviter de mourir.

Nous avons actuellement 3 Shaders : 
2 pour les spawners (1 pour l'effet de déformation autour et 1 pour la sphère au centre).
1 pour 2 objets présents vers le centre de la scène principale.

Nous avons également 2 Particle Systems :
1 Particle System classique pour la spirale autour des spawners.
1 Visual Effect Graph pour les particules qui orbitent autour des spawners.

Chaque spawner a une Point Light de sa couleur.
Nous utilisons également une Directional Light pour l'éclairage global.

Pour des raisons d'optimisations, nous avons décider d'utiliser une Pool pour les ennemis ainsi qu'une autre pour les balles.

Les ennemis utilisent un navMesh afin de se déplacer.

Il reste actuellement 2 warnings lors du build pour lesquels nous n'avons pas trouvé de fix.
Le premier est lié à un shader, et le second à un système de particules.

Normalement chaque élément du projet est dans un dossier correspondant.
Le dossier import correspond aux assets récupérés de l'asset store (certains ont été modifiés pour qu'ils fonctionnent avec notre projet).