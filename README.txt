Projet Echec corrige

1. Ouvrir Echec.slnx dans Visual Studio.
2. Vérifier que le SDK .NET 10 est installé (le projet cible net10.0-windows et utilise WPF).
3. Lancer avec F5.

La logique du jeu a ete reprise dans MainWindow.xaml.cs : mouvements des pieces, validation de la securite du roi, roque, prise en passant, promotion, echec, echec et mat et pat.
Les images d'origine et les classes de base sont conservees.

Note : l'environnement de preparation ne disposait pas du SDK dotnet, donc une compilation locale n'a pas pu etre lancee ici. Si Visual Studio affiche une erreur au premier lancement, transmettre le texte exact de l'erreur pour correction.
