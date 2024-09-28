import random
import math
from engine import GameEngine

def generate_question_and_answer():
    numbers = [random.randint(1, 20) for _ in range(3)]
    question = ' '.join(map(str, numbers))
    lcm = calculate_lcm(numbers)
    return question, lcm

def calculate_lcm(numbers):
    """Вычисляет НОК для списка чисел."""
    lcm = numbers[0]
    for i in numbers[1:]:
        lcm = lcm * i // math.gcd(lcm, i)
    return lcm

def main():
    game_name = "brain-scm"
    game_description = "Find the smallest common multiple of given numbers."
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