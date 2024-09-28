import random
from engine import GameEngine

def generate_question_and_answer():
    length = random.randint(5, 10)  # Длина прогрессии от 5 до 10
    start = random.randint(1, 10)   # Начальное число прогрессии
    ratio = random.randint(2, 5)    # Знаменатель прогрессии
    progression = [start * (ratio ** i) for i in range(length)]
    hidden_index = random.randint(0, length - 1)
    correct_answer = progression[hidden_index]
    progression[hidden_index] = '..'
    question = ' '.join(map(str, progression))
    return question, correct_answer

def main():
    game_name = "brain-progression"
    game_description = "What number is missing in the progression?"
    engine = GameEngine(game_name)

    # Спрашиваем у игрока, сколько раундов он хочет сыграть
    rounds_input = input("Enter number of rounds to play (or 'endless' for infinite mode): ").strip().lower()
    if rounds_input == 'endless':
        engine.play(game_description, generate_question_and_answer, endless=True)
    else:
        try:
            rounds = int(rounds_input)
            engine.play(game_description, generate_question_and_answer, rounds=rounds)
        except ValueError:
            print("Invalid input. Starting game with default 3 rounds.")
            engine.play(game_description, generate_question_and_answer)

if __name__ == "__main__":
    main()