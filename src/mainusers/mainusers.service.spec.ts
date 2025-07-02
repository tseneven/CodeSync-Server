import { Test, TestingModule } from '@nestjs/testing';
import { MainusersService } from './mainusers.service';

describe('MainusersService', () => {
  let service: MainusersService;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      providers: [MainusersService],
    }).compile();

    service = module.get<MainusersService>(MainusersService);
  });

  it('should be defined', () => {
    expect(service).toBeDefined();
  });
});
